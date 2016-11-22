using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Dynamics;
using Box2DX.Common;
using Box2DX.Collision;
using System.Windows.Forms;

namespace J_Gzimo
{
    class PhysicWorld
    {
        const float TIMESTEP = 1.0f / 100.0f;//时间片
        const int VELOCITY_ITERATION = 20;//速度迭代次数
        const int POSITION_ITERATION = 20;//位置迭代次数
        const int GRAVITY = 100;
        private World myWorld;//box2d物理世界

        /// <summary>
        /// 根据按键和body对象，对body进行该按键对应的操作
        /// </summary>
        /// <param name="body">按键操作的对象</param>
        /// <param name="key">按键</param>
        public void operateBody(Body body, string key, KeyType type)
        {
            //对该body添加操作
            Vec2 impluse = new Vec2();
            switch (type)
            {
                case KeyType.Down: impluse = new Vec2(0, 100 * body.GetMass()); break;
                case KeyType.Up: impluse = new Vec2(0, -100 * body.GetMass()); break;
                case KeyType.Left: impluse = new Vec2(-50 * body.GetMass(), 0); break;
                case KeyType.Right: impluse = new Vec2(50 * body.GetMass(), 0); break;
            }
            body.ApplyImpulse(impluse, body.GetWorldCenter());

        }

        /// <summary>
        /// 初始化世界，根据场景变量，生成box2d物理世界
        /// </summary>
        public void initialWorld(Scene scene)
        {
            try
            {
                //初始化物理世界
                AABB worldAABB = new AABB();
                worldAABB.LowerBound.Set(-100f, -100f);
                worldAABB.UpperBound.Set(100.0f, 100.0f);
                Vec2 gravity = new Vec2(0, GRAVITY);//物理世界重力
                myWorld = new World(worldAABB, gravity, true);
                MyContactListener contactListener = new MyContactListener();
                myWorld.SetContactListener(contactListener);

                for (int i = 0; i < scene.Gizmos.Count; i++)
                {
                    GizmoComponents myGizmo = scene.Gizmos[i];//获取gizmo对象 
                    BodyDef bodyDef = new BodyDef();
                    bodyDef.Position.Set(myGizmo.PositionX, myGizmo.PositionY);//设置gizmo在物理世界的位置
                    bodyDef.Angle = (float)(myGizmo.Angle / 180 * System.Math.PI);
                    Body body = myWorld.CreateBody(bodyDef);//在物理世界中添加gizmo
                    body.SetUserData(myGizmo);

                    //添加shape
                    switch (myGizmo.Shape)
                    {
                        case GizmoType.Circle:
                            addCircle(body);
                            break;
                        case GizmoType.Rectangle:
                            addRectangle(body);
                            break;
                        case GizmoType.Polygon:
                            addPolygon(body);
                            break;
                        case GizmoType.Baffle:
                            addBaffle(body);
                            break;
                        case GizmoType.BaffleX:
                            addBaffleX(body);
                            break;
                    }

                    //添加运动状态
                    if (myGizmo.IsStatic == 0)
                    {
                        switch (myGizmo.Attribute)
                        {
                            case GizmoAttribute.dynamicGizmo:
                                body.SetMassFromShapes();
                                body.ApplyForce(body.GetMass() * myWorld.Gravity * -1, body.GetWorldCenter());
                                break;
                            case GizmoAttribute.pineBall:
                                body.SetMassFromShapes();
                                body.ApplyImpulse(new Vec2(myGizmo.VelocityX * body.GetMass(), myGizmo.VelocityY * body.GetMass()), body.GetWorldCenter());
                                break;
                            case GizmoAttribute.baffle:
                                body.SetMassFromShapes();
                                break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicWorld-initialWorld函数出错");
            }
        }

        /// <summary>
        /// 物理世界根据时间粒度前进一步
        /// </summary>
        public void stepWorld()
        {
            try
            {
                myWorld.Step(TIMESTEP, VELOCITY_ITERATION, POSITION_ITERATION);
                Body body = myWorld.GetBodyList();
                for (int i = 0; i < myWorld.GetBodyCount(); i++)
                {
                    if (body.GetUserData() != null)
                    {
                        GizmoComponents gizmo = (GizmoComponents)body.GetUserData();
                        if (GizmoAttribute.dynamicGizmo == gizmo.Attribute)
                        {
                            body.ApplyForce(body.GetMass() * myWorld.Gravity * -1, body.GetWorldCenter());
                        }
                    }
                    body = body.GetNext();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-stepWorld函数出错");
            }
        }

        #region addShape
        private void addCircle(Body body)
        {
            try
            {
                if (body.GetUserData() == null) return;
                GizmoComponents myGizmo = (GizmoComponents)body.GetUserData();
                CircleDef circleDef = new CircleDef();
                circleDef.Radius = myGizmo.Radius;
                circleDef.Density = myGizmo.Density;
                circleDef.Restitution = myGizmo.Restitution;
                circleDef.Friction = myGizmo.Friction;
                body.CreateFixture(circleDef);
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-addBaffleX函数出错");
            }
        }
        private void addRectangle(Body body)
        {
            try
            {
                if (body.GetUserData() == null) return;
                GizmoComponents myGizmo = (GizmoComponents)body.GetUserData();
                PolygonDef rectangleDef = new PolygonDef();
                rectangleDef.SetAsBox(myGizmo.Width, myGizmo.Height);
                rectangleDef.Density = myGizmo.Density;
                rectangleDef.Restitution = myGizmo.Restitution;
                rectangleDef.Friction = myGizmo.Friction;
                body.CreateFixture(rectangleDef);
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-addBaffleX函数出错");
            }
        }
        private void addPolygon(Body body)
        {
            try
            {
                if (body.GetUserData() == null) return;
                GizmoComponents myGizmo = (GizmoComponents)body.GetUserData();
                PolygonDef polygonDef = new PolygonDef();
                polygonDef.Density = myGizmo.Density;
                polygonDef.Restitution = myGizmo.Restitution;
                polygonDef.Friction = myGizmo.Friction;
                for (int i = 0; i < myGizmo.Polygons.Count; i++)
                {
                    polygonDef.VertexCount = myGizmo.Polygons[i].Count;
                    for (int j = 0; j < myGizmo.Polygons[i].Count; j++)
                    {
                        polygonDef.Vertices[j].Set(myGizmo.Polygons[i][j].X, myGizmo.Polygons[i][j].Y);
                    }
                    body.CreateFixture(polygonDef);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-addBaffleX函数出错");
            }
        }
        private void addBaffle(Body body)
        {
            try
            {
                if (body.GetUserData() == null) return;
                GizmoComponents myGizmo = (GizmoComponents)body.GetUserData();
                //添加Shape
                addPolygon(body);
                //添加旋转关节
                BodyDef kinematicBodyDef = new BodyDef();
                Vec2 position = GizmoShape.PointRotate(new Vec2(myGizmo.PositionX, myGizmo.PositionY),
                    new Vec2(myGizmo.PositionX + myGizmo.Width, myGizmo.PositionY), System.Math.PI * 2 - myGizmo.Angle / 180 * System.Math.PI);
                kinematicBodyDef.Position.Set(position.X, position.Y);
                Body kinematicBody = myWorld.CreateBody(kinematicBodyDef);
                RevoluteJointDef jointDef = new RevoluteJointDef();
                switch ((int)myGizmo.Angle)
                {
                    case 0:
                        jointDef.LowerAngle = -1.57f;//最小角
                        jointDef.UpperAngle = 0;//最大角
                        break;
                    case 90:
                        jointDef.LowerAngle = -1.57f;//最小角
                        jointDef.UpperAngle = 1.57f;//最大角
                        break;
                    case 180:
                        jointDef.LowerAngle = 0f;//最小角
                        jointDef.UpperAngle = 1.57f;//最大角
                        break;
                    case 270:
                        jointDef.LowerAngle = 0f;//最小角
                        jointDef.UpperAngle = 1.57f;//最大角
                        break;
                }
                jointDef.EnableLimit = true;
                jointDef.MaxMotorTorque = 100.0f;
                jointDef.MotorSpeed = 0.0f;
                jointDef.EnableMotor = true;
                jointDef.Initialize(body, kinematicBody, position);
                RevoluteJoint joint = (RevoluteJoint)myWorld.CreateJoint(jointDef);
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-addBaffleX函数出错");
            }
        }
        private void addBaffleX(Body body)
        {
            try
            {
                if (body.GetUserData() == null) return;
                GizmoComponents myGizmo = (GizmoComponents)body.GetUserData();
                //添加Shape
                addPolygon(body);

                BodyDef kinematicBodyDef = new BodyDef();
                kinematicBodyDef.Position.Set(0, myGizmo.PositionY);
                Body kinematicBody = myWorld.CreateBody(kinematicBodyDef);

                PrismaticJointDef jointDef = new PrismaticJointDef();
                Vec2 worldAxis = new Vec2(1, 0);
                jointDef.Initialize(body, kinematicBody, kinematicBody.GetWorldCenter(), worldAxis);
                jointDef.LowerTranslation = -100f;
                jointDef.UpperTranslation = 100f;
                jointDef.EnableLimit = true;
                PrismaticJoint joint = (PrismaticJoint)myWorld.CreateJoint(jointDef);
            }
            catch (Exception e)
            {
                MessageBox.Show("PhysicalWorld-addBaffleX函数出错");
            }
        }
        #endregion

        #region Get和Set函数
        public World MyWorld
        {
            get
            {
                return myWorld;
            }

            set
            {
                myWorld = value;
            }
        }
        #endregion
    }
}
