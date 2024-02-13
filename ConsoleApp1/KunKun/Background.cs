using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class Background : GameObject
    {
        public float witdh { get; set; }
        public override void initialize()
        {

            this.Transform.X = 0f;
            this.Transform.Y = 0f;
            this.witdh = 1920;
            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("background-test.jpg");


            addTag("Background");
        }

        public bool isLastScreen() {
            int screenWidth = Bootstrap.getDisplay().getWidth();
            if (this.witdh + this.Transform.X <= screenWidth)
            {
                return true;
            }

            return false;
        }

        public void updateBackgroundPosition(Character character)
        {
            int screenWidth = Bootstrap.getDisplay().getWidth();

            Debug.Log("background x: {}" + this.Transform.X);
            Debug.Log("character x: {}" + character.Transform.X);

            if (this.isLastScreen())
            {
                return;
            }

            if (character.isFacingRight && character.reachRightScreen())
            {
                this.Transform.X -= character.speed;
            }
        }







        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }
    }
}
