using Box2DX.Common;
using Box2DX.Dynamics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Gzimo
{
    class GizmoShape
    {
        public class Triangle
        {
            static public List<List<PointF>> getPolygons(int size,float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                polygons.Add(getVectors(size,interval));
                return polygons;
            }
            static public List<PointF> getVectors(int size,float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval, -size * interval));
                vectors.Add(new PointF(size * interval, -size * interval));
                vectors.Add(new PointF(-size * interval, size * interval));
                return vectors;
            }
            static public List<Point> getPoint(int size,int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size-i; j++)
                    {
                        Point p = new Point(i,j);
                        points.Add(PointRotate(p, size, angle));
                    }
                }
                return points;
            }
        }
        public class Trapezoid
        {
            static public List<List<PointF>> getPolygons(int size, float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                polygons.Add(getVectors(size, interval));
                return polygons;
            }
            static public List<PointF> getVectors(int size, float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval, -size * interval));
                vectors.Add(new PointF(size * interval, -size * interval));
                vectors.Add(new PointF(size * interval / 2, size * interval));
                vectors.Add(new PointF(size * interval / -2, size * interval));
                return vectors;
            }
            static public List<Point> getPoint(int size,int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size; i++)
                {
                    for (int j = i/4; j <size-i/4; j++)
                    {
                        Point p = new Point(i, j);
                        points.Add(PointRotate(p, size, angle));
                    }
                }
                return points;
            }
        }
        public class L
        {
            static public List<List<PointF>> getPolygons(int size, float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                List<PointF> polygon1 = new List<PointF>();
                polygon1.Add(new PointF(-size * interval, -size * interval));
                polygon1.Add(new PointF(0, -size * interval));
                polygon1.Add(new PointF(0, size * interval));
                polygon1.Add(new PointF(-size * interval, size * interval));
                polygons.Add(polygon1);
                List<PointF> polygon2 = new List<PointF>();
                polygon2.Add(new PointF(0, 0));
                polygon2.Add(new PointF(size * interval, 0));
                polygon2.Add(new PointF(size * interval, size * interval));
                polygon2.Add(new PointF(0, size * interval));
                polygons.Add(polygon2);              
                return polygons;
            }
            static public List<PointF> getVectors(int size, float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval, -size * interval));
                vectors.Add(new PointF(0, -size * interval));
                vectors.Add(new PointF(0, 0));
                vectors.Add(new PointF(size * interval, 0));
                vectors.Add(new PointF(size * interval, size * interval));
                vectors.Add(new PointF(-size * interval, size * interval));
                return vectors;
            }
            static public List<Point> getPoint(int size,int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size; i++)
                {
                    Point p=new Point();
                    if (i < size / 2.0f)
                    {
                        for (int j = 0; j < size ; j++)
                        {
                            p = new Point(i, j);
                            points.Add(PointRotate(p, size, angle));
                        }
                    }
                    else
                    {
                        for (int j = size-1; j >= size/2; j--)
                        {
                            p = new Point(i, j);
                            points.Add(PointRotate(p, size, angle));
                        }
                    }
                    
                }
                return points;
            }
        }
        public class Circle
        {
            static public List<Point> getPoint(int size,int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Point p = new Point(i, j);
                        if (!isIn(p, size))
                        {
                            points.Add(PointRotate(p,size,angle));
                        }
                    }
                }
                return points;
            }
            static private bool isIn(Point p,int size)
            {
                PointF[] point = new PointF[5];
                PointF center = new PointF(size/2.0f, size/2.0f);
                point[0] = new PointF(p.X, p.Y);
                point[1] = new PointF(p.X+1, p.Y);
                point[2] = new PointF(p.X, p.Y+1);
                point[3] = new PointF(p.X+1, p.Y+1);
                point[4] = new PointF(p.X+0.5f, p.Y+0.5f);
                bool isIn = true;
                for (int i = 0; i < 5; i++)
                {
                    if (System.Math.Pow(point[i].X - center.X, 2) + System.Math.Pow(point[i].Y - center.Y, 2) <= System.Math.Pow(size / 2.0f, 2))
                    {
                        isIn = false;
                    }
                }
                return isIn;
            }

        }
        public class Square
        {
            static public List<List<PointF>> getPolygons(int size, float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                polygons.Add(getVectors(size, interval));
                return polygons;
            }
            static public List<PointF> getVectors(int size, float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval, -size * interval));
                vectors.Add(new PointF(size * interval, -size * interval));
                vectors.Add(new PointF(size * interval, size * interval));
                vectors.Add(new PointF(-size * interval, size * interval));
                return vectors;
            }
            static public List<Point> getPoint(int size, int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Point p = new Point(i, j);
                        points.Add(p);
                    }
                }
                return points;
            }
        }
        public class Rectangle
        {
            static public List<List<PointF>> getPolygons(int size, float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                polygons.Add(getVectors(size,interval));
                return polygons;
            }
            static public List<PointF> getVectors(int size, float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval, -size * interval/3.0f));
                vectors.Add(new PointF(size * interval, -size * interval/3.0f));
                vectors.Add(new PointF(size * interval, size * interval/3.0f));
                vectors.Add(new PointF(-size * interval, size * interval/3.0f));
                return vectors;
            }
            static public List<Point> getPoint(int size, int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i <size ; i++)
                {
                    for(int j = 0; j < (size - 1) / 3 + 1; j++)
                    {
                        Point p = new Point(i, j);
                        points.Add(p);
                    }
                }
                return points;
            }
        }
        public class BaffleX
        {
            static public List<List<PointF>> getPolygons(int size, float interval)
            {
                List<List<PointF>> polygons = new List<List<PointF>>();
                polygons.Add(getVectors(size, interval));
                return polygons;
            }
            static public List<PointF> getVectors(int size, float interval)
            {
                List<PointF> vectors = new List<PointF>();
                vectors.Add(new PointF(-size * interval*4, -size * interval));
                vectors.Add(new PointF(size * interval*4, -size * interval));
                vectors.Add(new PointF(size * interval*4, size * interval));
                vectors.Add(new PointF(-size * interval*4, size * interval));
                return vectors;
            }
            static public List<Point> getPoint(int size, int angle)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < size*4; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Point p = new Point(i, j);
                        points.Add(p);
                    }
                }
                return points;
            }
        }
        
        /// <summary>
        /// 以center为中心旋转angle角度
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="p1">待旋转点</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        static private Point PointRotate(Point p,int size, int angle)
        {
            Point point = new Point();
            float centerX = (size-1) / 2.0f;
            float centerY = (size-1) / 2.0f;
            double anglePi = angle * System.Math.PI / 180;
            point.X = (int)(0.5 + (p.X - centerX) * System.Math.Cos(anglePi) - (p.Y - centerY) * System.Math.Sin(anglePi) + centerX);
            point.Y = (int)(0.5+(p.X - centerX) * System.Math.Sin(anglePi) + (p.Y - centerY) * System.Math.Cos(anglePi) + centerY);
            return point;
        }

        /// <summary>
        /// 根据body和scale找出顶点集合
        /// </summary>
        /// <param name="body">要找顶点的Body对象</param>
        /// <param name="scale">比例尺</param>
        /// <returns></returns>
        static public Queue<Point> getBodyPoint(Body body, double scale)
        {
            try
            {
                Queue<Point> q = new Queue<Point>();
                GizmoComponents gizmo = (GizmoComponents)body.GetUserData();
                for (int i = 0; i < gizmo.Vectors.Count; i++)
                {
                    Vec2 center = new Vec2(0, 0);
                    Vec2 start = new Vec2(gizmo.Vectors[i].X, gizmo.Vectors[i].Y);
                    double angle = body.GetAngle();
                    Vec2 result = PointRotate(center, start, body.GetAngle());
                    Point p = new Point((int)((result.X + body.GetPosition().X) * scale), (int)((result.Y + body.GetPosition().Y) * scale));
                    q.Enqueue(p);
                }
                return q;
            }
            catch (Exception e)
            {
                MessageBox.Show("GizmoShape-getBodyPoint函数出现错误");
                return null;
            }
        }

        /// <summary>
        /// 以center为中心旋转angle角度
        /// </summary>
        /// <param name="center">中心点</param>
        /// <param name="p1">待旋转点</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        static public Vec2 PointRotate(Vec2 center, Vec2 p1, double angle)
        {
            Vec2 p2 = new Vec2();
            p2.X = (float)((p1.X - center.X) * System.Math.Cos(angle) - (p1.Y - center.Y) * System.Math.Sin(angle) + center.X);
            p2.Y = (float)((p1.X - center.X) * System.Math.Sin(angle) + (p1.Y - center.Y) * System.Math.Cos(angle) + center.Y);
            return p2;
        }
    }
}
