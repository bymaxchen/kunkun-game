using SDL2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shard
{
    class Character : GameObject, CollisionHandler
    {
        public Vector2 jumpDirction { get; set; }
        public bool IsJumping { get; set; }
        public float speed = 5.0f; // Adjust speed as needed
        private bool facingRight = true;

        public bool isFacingRight
        {
            get { return facingRight; } // Getter for _myField
                                     // Optionally, you can also define a setter if needed
                                     // set { _myField = value; }
        }

        public override void initialize()
        {

            this.Transform.X = 100.0f;
            this.Transform.Y = 818.0f;

            setPhysicsEnabled();

            MyBody.Mass = 1;
            MyBody.MaxForce = 15;
            MyBody.Drag = 0f;
            MyBody.UsesGravity = true;
            MyBody.StopOnCollision = true;

            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("heizi.png");
            MyBody.addRectCollider();

            addTag("Character");
        }

        public void move(float deltaX)
        {
            if (IsJumping) return;

            if (deltaX > 0 && !facingRight)
            {
                Flip();
            }
            else if (deltaX < 0 && facingRight)
            {
                Flip();
            }
            this.Transform.translate(deltaX, 0);
        }

        private void Flip()
        {
            facingRight = !facingRight;
            if (facingRight)
            {
                this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("heizi.png");
            }
            else
            {
                this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("heizi-reverse.png");
            }
        }

        public override void update()
        {
            Bootstrap.getDisplay().addToDraw(this);
        }

        public override void physicsUpdate()
        {
        }



        public void handleInput(Background background, InputEvent inp, string eventType) {
            if (Bootstrap.getRunningGame().isRunning() == false)
            {
                return;
            }

            if (IsJumping) return;

            if (eventType == "KeyDown")
            {

                if ( inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_D)
                {
                    this.move(speed);
                    background.updateBackgroundPosition(this);
                }

                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_A)
                {
                    this.move(-speed);
                    background.updateBackgroundPosition(this);
                }

                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_W) {
                    IsJumping = true;
                    MyBody.stopForces();
                    MyBody.addForce(new Vector2(0, -1), 3);
                }

            }

        }

        public void onCollisionEnter(PhysicsBody x)
        {
            IsJumping = false;
        }

        public void onCollisionExit(PhysicsBody x)
        {

        }

        public void onCollisionStay(PhysicsBody x)
        {
        }
    }
}
