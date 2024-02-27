using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class Basketball : GameObject, CollisionHandler
    {
        private string destroyTag;
        private int dir;

        private readonly int width = 48;  
        private readonly int height = 48;

        public readonly int maxRange = 250; // basketball's max range

        private float initalX;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public string DestroyTag { get => destroyTag; set => destroyTag = value; }
        public int Dir { get => dir; set => dir = value; }

        public void setupBasketball(float x, float y, int dir)
        {
            this.Transform.X = x;
            this.Transform.Y = y;
            this.initalX = x;


            this.dir = dir;

            setPhysicsEnabled();

            MyBody.addRectCollider();

            addTag("Basketabll");
        }

        public override void initialize()
        {

            this.Transient = false;
            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("basketball.png");

        }

        public override void update()
        {
            if (Math.Abs(this.Transform.X - this.initalX) > maxRange)
            {
                this.ToBeDestroyed = true;
                return;
            }
            this.Transform.translate(dir * 400 * Bootstrap.getDeltaTime(), 0);

            Bootstrap.getDisplay().addToDraw(this);
        }

        public void onCollisionEnter(PhysicsBody x)
        {
            this.ToBeDestroyed = true;
        }

        public void onCollisionExit(PhysicsBody x)
        {

        }

        public void onCollisionStay(PhysicsBody x)
        {
        }
    }
}
