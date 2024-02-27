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

        private int width;  
        private int height;


        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public string DestroyTag { get => destroyTag; set => destroyTag = value; }
        public int Dir { get => dir; set => dir = value; }

        public void setupBasketball(float x, float y, int dir)
        {
            this.Transform.X = x;
            this.Transform.Y = y;


            this.dir = dir;

            setPhysicsEnabled();

            MyBody.addRectCollider();

            addTag("Basketabll");
        }

        public override void initialize()
        {
            this.width = 48;
            this.height = 48;
            this.Transient = true;
            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("basketball.png");

        }

        public override void update()
        {
            this.Transform.translate(dir * 400 * Bootstrap.getDeltaTime(), 0);

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
