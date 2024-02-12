using GameTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class KunKun : Game, InputListener
    {
        private Character character;
        private Background background;
        private Ground ground;
        public override void update()
        {

            Bootstrap.getDisplay().showText("FPS: " + Bootstrap.getSecondFPS() + " / " + Bootstrap.getFPS(), 10, 10, 12, 255, 255, 255);

        }
        public override int getTargetFrameRate()
        {
            return 60;

        }

        public override void initialize()
        {
            background = new Background();
            character = new Character();
            ground = new Ground();
           
            Bootstrap.getInput().addListener(this);
        }


        public void handleInput(InputEvent inp, string eventType)
        {
            character.handleInput(background, inp, eventType);

        }

    }
}
