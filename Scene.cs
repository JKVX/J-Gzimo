using Box2DX.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace J_Gzimo
{
    [Serializable]
    class Scene
    {
        private List<GizmoComponents> gizmos = new List<GizmoComponents>(); //场景中所有gizmo列表
        private List<GizmoOperation> gizmoOpera = new List<GizmoOperation>();//场景中gizmo被绑定的按键操作列表
        private int idNum = 1;//场景中gizmo的当前最大id，每添加一个gizmo,id++
        private Draw draw;

        public Scene()
        {
            gizmos = new List<GizmoComponents>();
            GizmoOpera = new List<GizmoOperation>();
            Draw draw = new Draw();
            int sideLength = draw.SideLength;
            int scale = draw.Scale;
            float wallLength = sideLength / (float)(scale);
            addWall(wallLength, 0, scale);
            addWall(wallLength, 1, scale);
            addWall(wallLength, 2, scale);
            addWall(wallLength, 3, scale);
        }

        [Serializable]
        /// <summary>
        /// 按键操作类，按键与gizmo的id绑定
        /// </summary>
        public class GizmoOperation
        {
            public GizmoOperation(int id, string operationKey, KeyType keyType)
            {
                this.id = id;
                this.operationKey = operationKey;
                this.keyType = keyType;
            }
            public int id;
            public string operationKey;
            public KeyType keyType;
        }

        /// <summary>
        /// 初始化场景，读取场景文件，为场景变量赋值
        /// </summary>
        public Scene InitialScene(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long size = fs.Length;
                byte[] bytes = new byte[size];
                fs.Read(bytes, 0, bytes.Length);
                Scene scene;
                //利用传来的byte[]创建一个内存流
                MemoryStream ms = new MemoryStream(bytes);
                ms.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                scene = (Scene)formatter.Deserialize(ms);//把内存流反序列成对象  
                ms.Close();
                return scene;
            }
            catch (Exception e)
            {
                MessageBox.Show("Scene-InitialScene函数出错");
                return null;
            }
        }

        /// <summary>
        /// 保存场景文件
        /// </summary>
        /// <param name="path"></param>
        public bool saveScene(string path,Draw drawInfo)
        {
            try
            {
                Draw = drawInfo;
                //内存实例
                MemoryStream ms = new MemoryStream();
                //创建序列化的实例
                BinaryFormatter formatter = new BinaryFormatter();
                long size = ms.GetBuffer().Length;
                formatter.Serialize(ms, this);//序列化对象，写入ms流中  
                ms.Position = 0;
                byte[] bytes = ms.GetBuffer();
                ms.Read(bytes, 0, bytes.Length);
                ms.Close();
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bytes);
                bw.Close();
                fs.Close();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Scene-saveScene函数出错");
                return false;
            }
        }

        /// <summary>
        /// 给gizmo绑定按键
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="gizmoId"></param>
        /// <param name="key"></param>
        public void bindKey(KeyType keyType, int gizmoId, string key)
        {
            GizmoOperation opera = new GizmoOperation(gizmoId, key, keyType);
            gizmoOpera.Add(opera);
        }

        /// <summary>
        /// 使gizmo变为轨道
        /// </summary>
        /// <param name="id"></param>
        public void becomeTrack(int id)
        {
            GizmoComponents gizmo = getGizmo(id);
            if (gizmo != null)
            {
                gizmo.Attribute = GizmoAttribute.track;
                gizmo.Friction = 0;
            }
        }

        /// <summary>
        /// 使gizmo变为吸收器
        /// </summary>
        /// <param name="id"></param>
        public void becomeAbsorber(int id)
        {
            GizmoComponents gizmo = getGizmo(id);
            if (gizmo != null)
            {
                gizmo.Attribute = GizmoAttribute.absorber;
                gizmo.Friction = 10;
            }
        }

        /// <summary>
        /// 使gizmo可动
        /// </summary>
        /// <param name="id"></param>
        public void becomeDynamic(int id)
        {
            GizmoComponents gizmo = getGizmo(id);
            if (gizmo != null)
            {
                gizmo.Attribute = GizmoAttribute.dynamicGizmo;
                gizmo.IsStatic = 0;
                gizmo.Friction = 0;
                gizmo.Density = 1;
                gizmo.Restitution = 1;
            }
        }

        /// <summary>
        /// 添加gizmo
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
        /// <param name="type"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public int addGizmo(float positionX, float positionY, int size, int angle, FormGizmoType type, float interval)
        {
            int id = 0;
            switch (type)
            {
                case FormGizmoType.Circle:
                    id = addCircle(positionX, positionY, size, interval); break;
                case FormGizmoType.Square:
                    id = addSquare(positionX, positionY, size, angle, interval); break;
                case FormGizmoType.Triangle:
                    id = addTriangle(positionX, positionY, size, angle, interval); break;
                case FormGizmoType.PineBall:
                    id = addPineBall(positionX, positionY, size, interval); break;
                case FormGizmoType.Trapezoid:
                    id = addTrapezoid(positionX, positionY, size, angle, interval); break;
                case FormGizmoType.L:
                    id = addL(positionX, positionY, size, angle, interval); break;
                case FormGizmoType.Baffle:
                    id = addBaffle(positionX, positionY, size, angle, interval); break;
                case FormGizmoType.BaffleX:
                    id = addBaffleX(positionX, positionY, size, angle, interval); break;
            }
            return id;
        }
             
        /// <summary>
        /// 根据删除gizmo
        /// </summary>
        /// <param name="id"></param>
        public void deleteGizmo(int id)
        {
            for(int i = 0; i < gizmos.Count; i++)
            {
                if (gizmos[i].Id == id)
                {
                    gizmos.Remove(gizmos[i]);
                    return;
                }
            }
        }

        /// <summary>
        /// 改变gizmo的大小、角度
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public int changeGizmo(float positionX, float positionY, int type, int id, float interval)
        {
            GizmoComponents gizmo = getGizmo(id);
            if (gizmo != null)
            {
                int size = gizmo.GizmoSize;
                int angle = (int)gizmo.Angle;
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
                        angle = (angle + 90) % 360;
                        break;
                }
                if (size != 0)
                {
                    deleteGizmo(id);
                    int newId = 0;
                    newId = addGizmo(positionX, positionY, size, angle, formGizmoType, interval);
                    for (int i = 0; i < GizmoOpera.Count; i++)
                    {
                        if (gizmoOpera[i].id == id)
                        {
                            gizmoOpera[i].id = newId;
                        }
                    }
                    return newId;
                }              
            }
            return -1;
        }

        /// <summary>
        ///根据id获取gizmo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GizmoComponents getGizmo(int id)
        {
            for(int i = 0; i < gizmos.Count; i++)
            {
                if (gizmos[i].Id == id)
                {
                    return gizmos[i];
                }
            }
            return null;
        }
    
        #region Get和Set函数
        internal List<GizmoComponents> Gizmos
        {
            get
            {
                return gizmos;
            }

            set
            {
                gizmos = value;
            }
        }

        internal List<GizmoOperation> GizmoOpera
        {
            get
            {
                return gizmoOpera;
            }

            set
            {
                gizmoOpera = value;
            }
        }

        internal Draw Draw
        {
            get
            {
                return draw;
            }

            set
            {
                draw = value;
            }
        }
        #endregion

        #region 添加Gizmo
        public int addPineBall(float positionX, float positionY, int size, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.PineBall;
            gizmo.Shape = GizmoType.Circle;
            gizmo.Attribute = GizmoAttribute.pineBall;
            gizmo.Id = idNum++;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Radius = size * interval;
            gizmo.GizmoSize = size;
            gizmo.VelocityX = 0;
            gizmo.VelocityY = -100;
            gizmo.IsStatic = 0;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addSquare(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.Square;
            gizmo.Shape = GizmoType.Polygon;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.Id = idNum++;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Polygons = GizmoShape.Square.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.Square.getVectors(size, interval);
            gizmo.Angle = angle;
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addTriangle(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.Triangle;
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.Polygon;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Angle = angle;
            gizmo.Polygons = GizmoShape.Triangle.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.Triangle.getVectors(size, interval);
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addCircle(float positionX, float positionY, int size, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.Circle;
            gizmo.Shape = GizmoType.Circle;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.Id = idNum++;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Radius = size * interval;
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addTrapezoid(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.Trapezoid;
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.Polygon;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Angle = angle;
            gizmo.Polygons = GizmoShape.Trapezoid.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.Trapezoid.getVectors(size, interval);
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addL(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.L;
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.Polygon;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Angle = angle;
            gizmo.Polygons = GizmoShape.L.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.L.getVectors(size, interval);
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addBaffle(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.Baffle;
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.Baffle;
            gizmo.Attribute = GizmoAttribute.baffle;
            gizmo.IsStatic = 0;
            gizmo.Angle = angle;
            gizmo.Density = 10.0f;
            gizmo.Width = interval * size;
            gizmo.Height = interval * size / 3.0f;
            gizmo.PositionX = positionX + interval * (size - 1);
            gizmo.PositionY = positionY + interval * (size/3.0f - 1);
            gizmo.Polygons = GizmoShape.Rectangle.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.Rectangle.getVectors(size, interval);
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        public int addBaffleX(float positionX, float positionY, int size, int angle, float interval)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.FormGizmoType = FormGizmoType.BaffleX;
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.BaffleX;
            gizmo.Attribute = GizmoAttribute.baffle;
            gizmo.IsStatic = 0;
            gizmo.Restitution = 1f;
            gizmo.Friction = 0;
            gizmo.Density = 1;
            gizmo.Width = interval * size*4;
            gizmo.Height = interval * size;
            gizmo.PositionX = positionX + interval * (size*4 - 1);
            gizmo.PositionY = positionY + interval * (size - 1);
            gizmo.Polygons = GizmoShape.BaffleX.getPolygons(size, interval);
            gizmo.Vectors = GizmoShape.BaffleX.getVectors(size, interval);
            gizmo.GizmoSize = size;
            gizmos.Add(gizmo);
            GizmoOperation gizmoOpe = new GizmoOperation(gizmo.Id,"Left",KeyType.Left);
            gizmoOpera.Add(gizmoOpe);
            gizmoOpe = new GizmoOperation(gizmo.Id, "Right", KeyType.Right);
            GizmoOpera.Add(gizmoOpe);
            return gizmo.Id;
        }
        /// <summary>
        /// 添加四周墙壁
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="wallLength"></param>
        /// <param name="type">0表示左墙1表示下墙2表示右墙3表示上墙</param>
        /// <returns></returns>
        public int addWall(float wallLength, int type, int scale)
        {
            GizmoComponents gizmo = new GizmoComponents();
            gizmo.Id = idNum++;
            gizmo.Shape = GizmoType.Rectangle;
            gizmo.Attribute = GizmoAttribute.staticGizmo;
            gizmo.IsStatic = 1;
            gizmo.Restitution = 1f;
            switch (type)
            {
                case 0:
                    gizmo.PositionX = 0;
                    gizmo.PositionY = 0;
                    gizmo.Width = 5.0f / scale;
                    gizmo.Height = wallLength;
                    break;
                case 1:
                    gizmo.PositionX = 0;
                    gizmo.PositionY = wallLength;
                    gizmo.Width = wallLength;
                    gizmo.Height = 5.0f / scale;
                    break;
                case 2:
                    gizmo.PositionX = wallLength;
                    gizmo.PositionY = 0;
                    gizmo.Width = 5.0f / scale;
                    gizmo.Height = wallLength;
                    break;
                case 3:
                    gizmo.PositionX = 0;
                    gizmo.PositionY = 0;
                    gizmo.Width = wallLength;
                    gizmo.Height = 5.0f / scale;
                    break;
            }
            gizmos.Add(gizmo);
            return gizmo.Id;
        }
        #endregion
    }
}
