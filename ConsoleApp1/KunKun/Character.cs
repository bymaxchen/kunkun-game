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

        public int width = 128;
        public int height = 128;

        private bool facingRight = true;

        private bool isDPressed = false;
        private bool isAPressed = false;
        private bool isWPressed = false;



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
            this.Transform2D.Wid = 128;

            setPhysicsEnabled();

            MyBody.Mass = 1;
            MyBody.MaxForce = 15;
            MyBody.Drag = 0f;
            MyBody.UsesGravity = true;
            MyBody.StopOnCollision = true;
            MyBody.addRectCollider();


            this.Transform.SpritePath = Bootstrap.getAssetManager().getAssetPath("heizi.png");


            addTag("Character");
        }

        // To judge if the center of charcter is located at the right screen

        public void move(float deltaX, Background background)
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

            if (!facingRight && this.Transform.X <= 0) {
                return;
            }

            this.Transform.translate(deltaX, 0);

/*            if (facingRight && background.isLastScreen() && this.Transform.X <= Bootstrap.getDisplay().getWidth() - this.width)
            {
                this.Transform.translate(deltaX, 0);
            }

            if ((!facingRight || !reachRightScreen())) {
                this.Transform.translate(deltaX, 0);
            }*/
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


            if (eventType == "KeyUp") {
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_A)
                {
                    this.isAPressed = false;
                }
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_W)
                {
                    this.isWPressed = false;
                }
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_D)
                {
                    this.isDPressed = false;
                }
            }

            if (IsJumping) return;

            if (eventType == "KeyDown")
            {
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_A)
                {
                    this.isAPressed = true;
                }
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_W)
                {
                    this.isWPressed = true;
                }
                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_D)
                {
                    this.isDPressed = true;
                }
                if (!isWPressed)
                {
                    if (isDPressed) // move foward
                    {
                        this.move(speed, background);
                    }
                    else if (isAPressed) // move backfoward
                    {
                        this.move(-speed, background);
                    }

                }
                else {
                    IsJumping = true;
                    MyBody.stopForces();
                    if (isDPressed) // jump foward
                    {
                        MyBody.addForce(new Vector2(0.5f, -1), 3);
                    }
                    else if (isAPressed) // jump backfoward
                    {
                        MyBody.addForce(new Vector2(-0.5f, -1), 3);
                    }
                    else { // jump vertically
                        MyBody.addForce(new Vector2(0, -1), 3);
                    }
                }


                if (inp.Key == (int)SDL.SDL_Scancode.SDL_SCANCODE_SPACE)
                {
                    fireBasketball();
                }
            }


        }

        public void fireBasketball() { 
            Basketball basketball = new Basketball();

            float x, y;
            int dir;

            y = this.Transform.Y + this.height / 2 - basketball.Height / 2;
            if (facingRight)
            {
                x = this.Transform.X + this.width;
                dir = 1;
            }
            else {
                x = this.Transform.X - basketball.Width;
                dir = -1;
            }

            basketball.setupBasketball(x, y, dir);
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
