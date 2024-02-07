using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class Background : GameObject
    {
        public override void initialize()
        {

            this.Transform.X = 0f;
            this.Transform.Y = 0f;
            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("background-test.jpg");


            addTag("Background");
        }

        public void updateBackgroundPosition(Character character)
        {
            // Check character movement direction
            if (character.isFacingRight)
            {
                this.Transform.X -= character.speed * 1.5f;
            }
            else if (!character.isFacingRight)
            {
                this.Transform.X += character.speed * 1.5f;
            }
        }


        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }
    }
}
