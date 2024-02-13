using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class Ground : GameObject, CollisionHandler
    {
        public Ground() {
            this.Transform.X = 0; 
            this.Transform.Y = 918.0f;
            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("missilecommandback.png");

            setPhysicsEnabled();


            
            MyBody.Mass = 10000;
            MyBody.MaxForce = 0;
            MyBody.Drag = 0f;
            MyBody.UsesGravity = false;
            MyBody.StopOnCollision = true;


            MyBody.addRectCollider();

            addTag("Ground");
        }

        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }

        public void onCollisionEnter(PhysicsBody x)
        {

        }

        public void onCollisionExit(PhysicsBody x)
        {

        }

        public void onCollisionStay(PhysicsBody x)
        {

        }
    }
}
