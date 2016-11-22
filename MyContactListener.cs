using Box2DX.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Collision;
using Box2DX.Common;
using System.Windows.Forms;

namespace J_Gzimo
{
    class MyContactListener:ContactListener
    {
        public void PostSolve(Contact contact, ContactImpulse impulse)
        {
        }

        public void PreSolve(Contact contact, Manifold oldManifold)
        {
        }

        void ContactListener.BeginContact(Contact contact)
        {
            try
            {
                Body bodyA = contact.FixtureA.Body;
                Body bodyB = contact.FixtureB.Body;
                GizmoComponents gizmoA = (GizmoComponents)bodyA.GetUserData();
                GizmoComponents gizmoB = (GizmoComponents)bodyB.GetUserData();
                if (gizmoA.FormGizmoType == FormGizmoType.BaffleX)
                {
                    bodyA.SetLinearVelocity(new Vec2(bodyA.GetLinearVelocity().X, 0));
                }
                if (gizmoB.FormGizmoType == FormGizmoType.BaffleX)
                {
                    bodyB.SetLinearVelocity(new Vec2(bodyB.GetLinearVelocity().X, 0));
                }
                switch (gizmoA.Attribute)
                {
                    case GizmoAttribute.absorber:
                        bodyB.SetLinearVelocity(new Vec2(0, 0));
                        bodyB.SetStatic();
                        break;
                    case GizmoAttribute.track:
                        bodyB.SetLinearVelocity(new Vec2(bodyB.GetLinearVelocity().X, 0));
                        break;
                    case GizmoAttribute.dynamicGizmo:
                        if (gizmoB.Attribute != GizmoAttribute.pineBall)
                        {
                            bodyA.SetLinearVelocity(new Vec2(0, 0));
                            bodyB.SetLinearVelocity(new Vec2(0, 0));
                        }
                        break;
                }
                switch (gizmoB.Attribute)
                {
                    case GizmoAttribute.absorber:
                        bodyA.SetLinearVelocity(new Vec2(0, 0));
                        bodyA.SetStatic();
                        break;
                    case GizmoAttribute.track:
                        bodyA.SetLinearVelocity(new Vec2(bodyA.GetLinearVelocity().X, 0));
                        break;
                    case GizmoAttribute.dynamicGizmo:
                        if (gizmoA.Attribute != GizmoAttribute.pineBall)
                        {
                            bodyA.SetLinearVelocity(new Vec2(0, 0));
                            bodyB.SetLinearVelocity(new Vec2(0, 0));
                        }
                        break;
                }
            }catch(Exception e)
            {
                MessageBox.Show("MyContactListener-BeginContact函数出错");
            }
        }

        void ContactListener.EndContact(Contact contact)
        {
            try
            {
                Body bodyA = contact.FixtureA.Body;
                Body bodyB = contact.FixtureB.Body;
                GizmoComponents gizmoA = (GizmoComponents)bodyA.GetUserData();
                GizmoComponents gizmoB = (GizmoComponents)bodyB.GetUserData();
                switch (gizmoA.Attribute)
                {
                    case GizmoAttribute.absorber:
                        bodyB.SetLinearVelocity(new Vec2(0, 0));
                        bodyB.SetStatic();
                        break;
                    case GizmoAttribute.track:
                        bodyB.SetLinearVelocity(new Vec2(bodyB.GetLinearVelocity().X, 0));
                        break;
                    case GizmoAttribute.dynamicGizmo:
                        if (gizmoB.Attribute != GizmoAttribute.pineBall)
                        {
                            bodyA.SetLinearVelocity(new Vec2(0, 0));
                            bodyB.SetLinearVelocity(new Vec2(0, 0));
                        }
                        break;
                }
                switch (gizmoB.Attribute)
                {
                    case GizmoAttribute.absorber:
                        bodyA.SetLinearVelocity(new Vec2(0, 0));
                        bodyA.SetStatic();
                        break;
                    case GizmoAttribute.track:
                        bodyA.SetLinearVelocity(new Vec2(bodyA.GetLinearVelocity().X, 0));
                        break;
                    case GizmoAttribute.dynamicGizmo:
                        if (gizmoA.Attribute != GizmoAttribute.pineBall)
                        {
                            bodyA.SetLinearVelocity(new Vec2(0, 0));
                            bodyB.SetLinearVelocity(new Vec2(0, 0));
                        }
                        break;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("MyContactListener-EndContact函数出错");
            }
        }


    }
}
