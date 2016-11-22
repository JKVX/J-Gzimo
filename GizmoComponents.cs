using Box2DX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing;
using Box2DX.Dynamics;

namespace J_Gzimo
{    
    [Serializable]
    class GizmoComponents
    {   
        #region 成员变量
        private int id=0;
        private GizmoType shape=GizmoType.Circle;//Gizmo形状 Circle;Rectangle;Polygon
        private float positionX=1;//Gizmo 初始X轴位置
        private float positionY=1;//Gizmo 初始Y轴位置
        private float radius=1;// Gizmo shape为Circle形状时表示半径
        private float density=0.5f;//Gizmo 密度
        private float friction=0.5f;//Gizmo 摩擦力
        private float restitution=1f;//Gizmo 恢复力
        private float width=1;//Gizmo shape为Rectangle、Polygon时表示半宽
        private float height=1;//Gizmo shape为Rectangle、Polygon时表示半高
        private float velocityX=0;//Gizmo  isStatic为0时表示X轴初始速度
        private float velocityY=0;//Gizmo isStatic为1时表示Y轴初始速度
        private float angle=0;//Gizmo 角度
        private int isStatic=1;//Gizmo是否可以移动
        private int gizmoSize = 1;//gizmo的放大倍数
        private GizmoAttribute attribute = GizmoAttribute.staticGizmo;//gizmo的属性
        private FormGizmoType formGizmoType = FormGizmoType.Circle;//form中的gizmo类型
        private List<PointF> vectors;//Gizmo shape为Polygon时表示多边形顶点
        private List<List<PointF>> polygons;
        List<string> operationKey;//Gizmo 绑定的操作键
        #endregion
        public GizmoComponents()
        {
            operationKey = new List<string>();
            vectors = new List<PointF>();
            polygons = new List<List<PointF>>();
        }
        /// <summary>
        /// gizmo绑定键盘按键
        /// </summary>
        /// <param name="operationKey"></param>
        public void bindKey(string operationKey) {
            this.operationKey.Add(operationKey);
        }
        /// <summary>
        /// shape为Polygon时，添加顶点
        /// 前置条件：顶点按逆时针顺序添加
        /// </summary>
        /// <param name="point"></param>
        public void addPolygon(List<PointF> polygon)
        {
            polygons.Add(polygon);
        }
        /// <summary>
        /// shape为Polygon时，添加顶点
        /// 前置条件：顶点按逆时针顺序添加
        /// </summary>
        /// <param name="point"></param>
        public void addVectors(PointF point)
        {
            vectors.Add(point);
        }
        #region Get和Set函数
        public float PositionX
        {
            get
            {
                return positionX;
            }

            set
            {
                positionX = value;
            }
        }

        public float PositionY
        {
            get
            {
                return positionY;
            }

            set
            {
                positionY = value;
            }
        }
        
        public float Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }

        public float Density
        {
            get
            {
                return density;
            }

            set
            {
                density = value;
            }
        }

        public float Friction
        {
            get
            {
                return friction;
            }

            set
            {
                friction = value;
            }
        }

        public float Restitution
        {
            get
            {
                return restitution;
            }

            set
            {
                restitution = value;
            }
        }

        public float Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public float Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public  List<PointF> Vectors
        {
            get
            {
                return vectors;
            }

            set
            {
                vectors = value;
            }
        }

        public float VelocityX
        {
            get
            {
                return velocityX;
            }

            set
            {
                velocityX = value;
            }
        }

        public float VelocityY
        {
            get
            {
                return velocityY;
            }

            set
            {
                velocityY = value;
            }
        }

        public GizmoType Shape
        {
            get
            {
                return shape;
            }

            set
            {
                shape = value;
            }
        }

        public float Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        public int IsStatic
        {
            get
            {
                return isStatic;
            }

            set
            {
                isStatic = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public List<List<PointF>> Polygons
        {
            get
            {
                return polygons;
            }

            set
            {
                polygons = value;
            }
        }

        public int GizmoSize
        {
            get
            {
                return gizmoSize;
            }

            set
            {
                gizmoSize = value;
            }
        }

        public FormGizmoType FormGizmoType
        {
            get
            {
                return formGizmoType;
            }

            set
            {
                formGizmoType = value;
            }
        }

        public GizmoAttribute Attribute
        {
            get
            {
                return attribute;
            }

            set
            {
                attribute = value;
            }
        }
        #endregion
    }
   
}
