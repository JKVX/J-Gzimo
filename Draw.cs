using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace J_Gzimo
{
    [Serializable]
    class Draw
    {
        int sideLength = 800;
        int squareNum=30;
        int scale = 20;
        public int interval;
        int[,] grid;
        Bitmap baseMap;
        Dictionary<int, PointF> gizmoClick = new Dictionary<int, PointF>();

        #region Get和Set函数
        public int SquareNum
        {
            get
            {
                return squareNum;
            }

            set
            {
                squareNum = value;
            }
        }

        public int Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public int SideLength
        {
            get
            {
                return sideLength;
            }

            set
            {
                sideLength = value;
            }
        }
        #endregion

        public Draw(int sqrNum=30)
        {
            this.squareNum = sqrNum;
            grid =new int[SquareNum+1,SquareNum+1];
            for (int i = 0; i < SquareNum+1; i++)
            {
                for(int j=0;j<SquareNum+1;j++)
                {
                    grid[i, j] = -1;
                }
            }
            interval = SideLength / SquareNum;
            baseMap = new System.Drawing.Bitmap(SideLength, SideLength);
            Graphics g = Graphics.FromImage(baseMap);
            Pen pen = new Pen(System.Drawing.Color.Pink);
            for(int i=0;i<=SquareNum;i++)
            {
                g.DrawLine(pen, new Point(i * interval, 0), new Point(i * interval, SideLength));
                g.DrawLine(pen, new Point(0, i * interval), new Point(SideLength, i * interval));
            }
        }
        public void draw(World world, Graphics g)
        {
            Body b = world.GetBodyList();
            int i = 0;
            do
            {
                SolidBrush brush;
                if (b.GetUserData() == null)
                {
                    i++;
                    b = b.GetNext();
                    continue;
                }
                GizmoComponents GComp = (GizmoComponents)b.GetUserData();
                switch(GComp.Attribute)
                {
                    case GizmoAttribute.pineBall:
                        brush = new SolidBrush(System.Drawing.Color.LawnGreen);
                        break;
                    case GizmoAttribute.staticGizmo:
                        brush = new SolidBrush(System.Drawing.Color.LightBlue);
                        break;
                    case GizmoAttribute.absorber:
                        brush = new SolidBrush(System.Drawing.Color.Red);
                        break;
                    case GizmoAttribute.dynamicGizmo:
                        brush = new SolidBrush(System.Drawing.Color.Yellow);
                        break;
                    case GizmoAttribute.track:
                        brush = new SolidBrush(System.Drawing.Color.Brown);
                        break;
                    case GizmoAttribute.baffle:
                        brush = new SolidBrush(System.Drawing.Color.Gray);
                        break;
                    default:
                        brush = new SolidBrush(System.Drawing.Color.Black);
                        break;
                }

                if (GComp == null) continue;
                switch (GComp.Shape)
                {
                    case GizmoType.Circle:
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.FillEllipse(brush, (b.GetPosition().X - GComp.Radius) * Scale, (b.GetPosition().Y - GComp.Radius) * Scale, GComp.Radius * 2 * Scale, GComp.Radius * 2 * Scale);
                        break;
                    case GizmoType.Rectangle:
                        g.FillRectangle(brush, (b.GetPosition().X - GComp.Width) * Scale+1, (b.GetPosition().Y - GComp.Height) * Scale+1, (GComp.Width) * Scale * 2-1, (GComp.Height) * Scale * 2-1);
                        break;
                    case GizmoType.BaffleX:
                    case GizmoType.Baffle:
                    case GizmoType.Polygon:
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.FillPolygon(brush, GizmoShape.getBodyPoint(b, Scale).ToArray());
                        break;
                }
                i++;
                b = b.GetNext();
            } while (i < world.GetBodyCount() - 1);
        }

        public Bitmap drawFrame(bool whetherStep,GizmoSystem gsystem)
        {
            Bitmap b = new System.Drawing.Bitmap(SideLength, SideLength);
            Graphics g = Graphics.FromImage(b);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(baseMap, new Point(0, 0));
            if (whetherStep)
                gsystem.stepWorld();
            draw(gsystem.PhysicWorld.MyWorld, g);
            g.Dispose();
            return b;
        }

        public Bitmap drawBaseMap()
        {
            Bitmap b = new System.Drawing.Bitmap(SideLength, SideLength);
            Graphics g = Graphics.FromImage(b);
            g.Clear(System.Drawing.Color.White);
            g.DrawImage(baseMap, new Point(0, 0));
            g.Dispose();
            return b;
        }

        public float convertFormToWorld(float before)
        {
            int index = (int)(before / interval);
            float after = (index*interval+ (float)interval/2) / Scale;
            return after;
        }

        public float getWorldInterval()
        {
            return interval /2.0f/ Scale;
        }

        public float convertWorldToForm(float before)
        {
            float after = before * Scale;
            return after;
        }

        public bool isAvailable(float X,float Y,List<Point> points,int originalId)
        {
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            foreach(Point p in points)
            {
                if (xIndex + p.X >= 0 && yIndex + p.Y >= 0 && xIndex + p.X < SquareNum && yIndex + p.Y <SquareNum)
                {
                    if (grid[xIndex + p.X, yIndex + p.Y] != -1 && grid[xIndex + p.X, yIndex + p.Y] != originalId)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool isAvailable(List<Point> points, int originalId)
        {
            float X = gizmoClick[originalId].X;
            float Y = gizmoClick[originalId].Y;
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            foreach (Point p in points)
            {
                if (xIndex + p.X >= 0 && yIndex + p.Y >= 0 && xIndex + p.X < SquareNum && yIndex + p.Y < SquareNum)
                {
                    if (grid[xIndex + p.X, yIndex + p.Y] != -1 && grid[xIndex + p.X, yIndex + p.Y] != originalId)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool fillGrid(float X,float Y,List<Point> points,int id)
        {
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            gizmoClick.Add(id, new PointF(X, Y));
            foreach(Point p in points)
            {
                grid[xIndex + p.X, yIndex + p.Y] = id;
            }
            return true;
        }

        public bool fillGrid( List<Point> points, int id,int originalId)
        {
            float X = gizmoClick[originalId].X;
            float Y = gizmoClick[originalId].Y;
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            gizmoClick.Add(id, new PointF(X, Y));
            foreach (Point p in points)
            {
                grid[xIndex + p.X, yIndex + p.Y] = id;
            }
            return true;
        }

        public int getGizmo(float X,float Y)
        {
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            int id = grid[xIndex, yIndex];
            return id;
        }

        public int deleteGizmo(float X,float Y)
        {
            int xIndex = (int)(X / interval);
            int yIndex = (int)(Y / interval);
            int id = grid[xIndex, yIndex];
            if (id != -1)
            {
                for (int i = 0; i < SquareNum; i++)
                {
                    for (int j = 0; j < SquareNum; j++)
                    {
                        if (grid[i, j] == id)
                            grid[i, j] = -1;
                    }
                }
                return id;
            }
            else
                return -1;
        }

        public void deleteGizmoById(int id)
        {
            for (int i = 0; i < SquareNum; i++)
            {
                for (int j = 0; j < SquareNum; j++)
                {
                    if (grid[i, j] == id)
                        grid[i, j] = -1;
                }
            }
        }
        
        public float getWorldPointXById(int id)
        {
            float before=gizmoClick[id].X;
            int index = (int)(before / interval);
            float after = (index * interval + (float)interval / 2) / Scale;
            return after;
        }

        public float getWorldPointYById(int id)
        {
            float before = gizmoClick[id].Y;
            int index = (int)(before / interval);
            float after = (index * interval + (float)interval / 2) / Scale;
            return after;
        }
    }
}
