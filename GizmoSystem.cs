using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace J_Gzimo
{
    class GizmoSystem
    {
        PhysicWorld physicWorld;
        Scene scene;

        public GizmoSystem()
        {
            PhysicWorld = new PhysicWorld();
            scene = new Scene();
        }

        /// <summary>
        /// 初始化box2d物理世界
        /// </summary>
        public void startGame()
        {
            PhysicWorld.initialWorld(scene);
        }

        /// <summary>
        /// 初始化读取scene文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Draw initialScene(string path)
        {
            try
            {
                scene = scene.InitialScene(path);
                return scene.Draw;
            }
            catch (Exception e)
            {
                throw (e);
                MessageBox.Show("GizmoSystem-initialScene函数出错");
                return null;
            }
        }

        /// <summary>
        /// 调用Scene类保存场景文件
        /// </summary>
        /// <returns></returns>
        public bool saveScene(string path, Draw drawInfo)
        {
            try {
                return scene.saveScene(path, drawInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show("GizmoSystem-saveScene函数出错");
                return false;
            }
        }

        /// <summary>
        /// 物理世界根据时间粒度前进一步
        /// </summary>
        public void stepWorld()
        {
            PhysicWorld.stepWorld();
        }

        /// <summary>
        /// 根据UI传过来的用户按键，进行相应操作
        /// </summary>
        /// <param name="Key"></param>
        public void keyDownOperation(string Key)
        {
            //判断按键是否在gizmoSystem中有对应的gizmo操作
            for (int i = 0; i < scene.GizmoOpera.Count; i++)
            {
                if (Key == scene.GizmoOpera[i].operationKey)
                {
                    for (Body b = PhysicWorld.MyWorld.GetBodyList(); b != null; b = b.GetNext())
                    {
                        if (b.GetUserData() != null)
                        {
                            GizmoComponents tmpGizmo = (GizmoComponents)b.GetUserData();
                            //找到按键对应的box2d物理世界中的body
                            if (scene.GizmoOpera[i].id == tmpGizmo.Id && scene.GizmoOpera[i].operationKey == Key)
                            {
                                PhysicWorld.operateBody(b, Key, scene.GizmoOpera[i].keyType);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定按键
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="gizmoId"></param>
        /// <param name="key"></param>
        public void bindKey(KeyType keyType, int gizmoId, string key)
        {
            scene.bindKey(keyType, gizmoId, key);
        }

        /// <summary>
        /// 在scene中添加gizmo
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
        /// <param name="type"></param>
        /// <param name="interval">网格在物理世界中的二分之一边长</param>
        /// <returns></returns>
        public int addGizmo(float positionX, float positionY, int size, int angle, FormGizmoType type, float interval)
        {
            return scene.addGizmo(positionX,positionY,size,angle,type,interval);
        }

        /// <summary>
        /// 在scene中删除gizmo
        /// </summary>
        /// <param name="id"></param>
        public void deleteGizmo(int id)
        {
            scene.deleteGizmo(id);
        }

        /// <summary>
        /// 根据size、angle、gizmo的种类获取该gizmo各个顶点相较于(0,0)的坐标
        /// </summary>
        /// <param name="type">gizmo的种类</param>
        /// <param name="size">gizmo的放大倍数</param>
        /// <param name="angle">gizmo的旋转角度</param>
        /// <returns></returns>
        public List<Point> getRelativePoint(FormGizmoType type, int size, int angle)
        {
            List<Point> points = new List<Point>();
            switch (type)
            {
                case FormGizmoType.Circle:
                    points = GizmoShape.Circle.getPoint(size, angle); break;
                case FormGizmoType.Square:
                    points = GizmoShape.Square.getPoint(size, angle); break;
                case FormGizmoType.Triangle:
                    points = GizmoShape.Triangle.getPoint(size, angle); break;
                case FormGizmoType.PineBall:
                    points = GizmoShape.Circle.getPoint(size, angle); break;
                case FormGizmoType.Trapezoid:
                    points = GizmoShape.Trapezoid.getPoint(size, angle); break;
                case FormGizmoType.L:
                    points = GizmoShape.L.getPoint(size, angle); break;
                case FormGizmoType.Baffle:
                    points = GizmoShape.Rectangle.getPoint(size, angle); break;
                case FormGizmoType.BaffleX:
                    points = GizmoShape.BaffleX.getPoint(size, angle); break;
            }
            return points;
        }

        /// <summary>
        /// 获取转换后新的gizmo各顶点的相对坐标
        /// </summary>
        /// <param name="type">0表示放大1表示缩小2表示旋转</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Point> getChangeRelativePoint(int type, int id)
        {
            GizmoComponents gizmo = scene.getGizmo(id);
            if (gizmo != null)
            {
                int size = gizmo.GizmoSize;
                int angle = (int)(gizmo.Angle * 180 / System.Math.PI);
                FormGizmoType formGizmoType = gizmo.FormGizmoType;
                switch (type)
                {
                    case 0:
                        size++;
                        break;
                    case 1:
                        size--;
                        break;
                    case 2:
                        angle = angle + 90;
                        break;
                }
                if (size != 0)
                {
                    return getRelativePoint(formGizmoType, size, angle);
                }
            }
            return null;
        }

        /// <summary>
        /// 改变gizmo大小角度状态
        /// </summary>
        /// <param name="type">改变类型 0表示放大1表示缩小2表示旋转</param>
        /// <param name="id"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public int changeGizmo(float positionX,float positionY,int type, int id, float interval)
        {
            return scene.changeGizmo(positionX, positionY, type, id, interval);
        }

        /// <summary>
        /// 使gizmo变为轨道
        /// </summary>
        /// <param name="id"></param>
        public void becomeTrack(int id)
        {
            scene.becomeTrack(id);
        }

        /// <summary>
        /// 使gizmo变为吸收器
        /// </summary>
        /// <param name="id"></param>
        public void becomeAbsorber(int id)
        {
            scene.becomeAbsorber(id);
        }

        /// <summary>
        /// 使gizmo可动
        /// </summary>
        /// <param name="id"></param>
        public void becomeDynamic(int id)
        {
            scene.becomeDynamic(id);
        }

        #region Get和Set函数
        internal PhysicWorld PhysicWorld
        {
            get
            {
                return physicWorld;
            }

            set
            {
                physicWorld = value;
            }
        }
        #endregion
    }
}
