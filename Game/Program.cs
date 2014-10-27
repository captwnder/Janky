using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace SFML_Test
{
    static class Program
    {

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        [STAThread]
        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            app.Closed += new EventHandler(OnClose);

            Color windowColor = new Color(0, 0, 0);

            Game.GameClock Clock;
            Clock = new Game.BasicGameClock();


            //Texture PlayerTexture = new Texture("../../Assets/Sprites/player.bmp");
            Game.AnimatedSprite PlayerSprite = new Game.BasicAnimatedSprite("../../Assets/Sprites/test1.png", 32, 48, 4, 50, false,0);
            Game.AnimatedSprite PlayerSpriteDown = new Game.BasicAnimatedSprite("../../Assets/Sprites/test1.png", 32, 48, 4, 50, false, 0);
            Game.AnimatedSprite PlayerSpriteLeft = new Game.BasicAnimatedSprite("../../Assets/Sprites/test1.png", 32, 48, 4, 50, false, 1);
            Game.AnimatedSprite PlayerSpriteRight = new Game.BasicAnimatedSprite("../../Assets/Sprites/test1.png", 32, 48, 4, 50, false, 2);
            Game.AnimatedSprite PlayerSpriteUp = new Game.BasicAnimatedSprite("../../Assets/Sprites/test1.png", 32, 48, 4, 50, false, 3);
            float xpos = 200;
            float ypos = 200;

            List<Game.Entity> Projectiles = new List<Game.Entity>();
            Boolean shootProjectile = false;
            Boolean shootButtonHeld = false;
            float xShootLeft = 0;
            float xShootRight = 0;
            float yShootUp = 0;
            float yShootDown = 0;
            float shotDistance = 100;

            //Int32 ticksJumping = 0;
            Int32 TotalLoops = 0;
            //Int32 maxTicksJumping = 1000;
            //Boolean touchedFloor = false;

            //Game.SoundHandler BGMusic = new Game.BasicMusicHandler("../../Assets/Sound/background.wav");
            //BGMusic.Loops(true);
            Game.SoundHandler BoomNoise = new Game.BasicSoundHandler("../../Assets/Sound/boom.wav");
            Boolean PlayOnce = true;

            String PlayerInputType;
            Game.PlayerInputBinary Movement = new Game.BasicPlayerInputBinaryKeyboard();
            //PlayerInputType = "keyboard";
            Game.PlayerInputAnalog Movement2 = new Game.BasicPlayerInputAnalogController();
            PlayerInputType = "controller";
            
            Int32 TicksThisLoop = 0;
            
            Font font = new Font("../../Assets/Fonts/Arial.ttf");
            Text text2 = new Text("",font,10);
            String ShotDirection = "";

            Image BGImage = new Image("../../Assets/Sprites/tile_test1.jpg");

            
            //BGMusic.Play();
            // Start the game loop
            while (app.IsOpen())
            {
                // Process events
                app.DispatchEvents();
                
                // Clear screen
                app.Clear(windowColor);
                
         
                //switch (PlayerInputType) {
                //    case "keyboard":
                //        if (Movement.Right())
                //        {
                //            xpos = xpos + TicksThisLoop / 10;
                //        }

                //        if (Movement.Left())
                //        {
                //            xpos = xpos - TicksThisLoop / 10;
                //        }

                //        if (Movement.Up())
                //        {
                //            ypos = ypos - TicksThisLoop / 10;
                //        }

                //        if (Movement.Down())
                //        {
                //            ypos = ypos + TicksThisLoop / 10;
                //        }

                //        if (Movement.Jump())
                //        {
                //            ypos = ypos - TicksThisLoop / 5;
                //        }
                //        else
                //        {
                //            ypos = ypos + TicksThisLoop / 5;
                //        }
                //    break;
                //    case "controller";
                        //Movement
                        //xpos = xpos + ((TicksThisLoop / 10) * Movement2.Right()) - ((TicksThisLoop / 10) * Movement2.Left());
                        //ypos = ypos + ((TicksThisLoop / 10) * Movement2.Down()) - ((TicksThisLoop / 10) * Movement2.Up());

                        if (Movement2.Up() > 0.2 || Movement.Up())
                        {
                            ypos = ypos - ((TicksThisLoop / 10));
                            PlayerSprite = PlayerSpriteUp;
                            PlayerSprite.Update(TicksThisLoop);
                        }
                        
                        if (Movement2.Down() > 0.2 || Movement.Down())
                        {
                            ypos = ypos + ((TicksThisLoop / 10));
                            PlayerSprite = PlayerSpriteDown;
                            PlayerSprite.Update(TicksThisLoop);
                        }

                        if (Movement2.Left() > 0.2 || Movement.Left())
                        {
                            xpos = xpos - ((TicksThisLoop / 10));
                            PlayerSprite = PlayerSpriteLeft;
                            PlayerSprite.Update(TicksThisLoop);
                        }
                        
                        if (Movement2.Right() > 0.2 || Movement.Right())
                        {
                            xpos = xpos + ((TicksThisLoop / 10));
                            PlayerSprite = PlayerSpriteRight;
                            PlayerSprite.Update(TicksThisLoop);
                        }

                        //change sprite direction while shooting
                        if (Movement2.Up2() > .2 || Movement2.Button4() || Movement.ShootUp())
                        {
                            PlayerSprite = PlayerSpriteUp;
                            PlayerSprite.Update(TicksThisLoop);
                            ShotDirection = "Up";
                            shootProjectile = true;
                            //shootButtonHeld = true;
                            xShootLeft = 0;
                            xShootRight = 0;
                            yShootUp = 1;
                            yShootDown = 0;
                        }
                        else if (Movement2.Down2() > .2 || Movement2.Button1() || Movement.ShootDown())
                        {
                            PlayerSprite = PlayerSpriteDown;
                            PlayerSprite.Update(TicksThisLoop);
                            ShotDirection = "Down";
                            shootProjectile = true;
                            //shootButtonHeld = true;
                            xShootLeft = 0;
                            xShootRight = 0;
                            yShootUp = 0;
                            yShootDown = 1;
                        }
                        else if (Movement2.Left2() > .2 || Movement2.Button3() || Movement.ShootLeft())
                        {
                            PlayerSprite = PlayerSpriteLeft;
                            PlayerSprite.Update(TicksThisLoop);
                            ShotDirection = "Left";
                            shootProjectile = true;
                            //shootButtonHeld = true;
                            xShootLeft = 1;
                            xShootRight = 0;
                            yShootUp = 0;
                            yShootDown = 0;
                        }
                        else if (Movement2.Right2() > .2 || Movement2.Button2() || Movement.ShootRight())
                        {
                            PlayerSprite = PlayerSpriteRight;
                            PlayerSprite.Update(TicksThisLoop);
                            ShotDirection = "Right";
                            shootProjectile = true;
                            //shootButtonHeld = true;
                            xShootLeft = 0;
                            xShootRight = 1;
                            yShootUp = 0;
                            yShootDown = 0;
                        }
                        else 
                        { 
                            ShotDirection = "";
                            shootProjectile = false;
                            shootButtonHeld = false;

                            xShootLeft = 0;
                            xShootRight = 0;
                            yShootUp = 0;
                            yShootDown = 0;
                        }
                        

                        //Debug Text
                        String Debug = "R: " + Movement2.Right() + "\nL: " + Movement2.Left() + "\nD: " + Movement2.Down() + "\nU: " + Movement2.Up();
                        Debug = Debug + "\nShot: " + ShotDirection;
                        text2.DisplayedString = Debug;
                        app.Draw(text2);

                        

                        //if (Movement2.Button1() && (ticksJumping < maxTicksJumping))
                        //{
                        //        ypos = ypos - TicksThisLoop / 5;
                        //        ticksJumping = ticksJumping + TicksThisLoop;
                        //}
                        //else
                        //{
                        //    ypos = ypos + TicksThisLoop / 5;
                        //    if (touchedFloor && !Movement2.Button1())
                        //    {
                        //        ticksJumping = 0;
                        //    }
                        //    else if (!touchedFloor && !Movement2.Button1())
                        //    {
                        //        ticksJumping = maxTicksJumping;
                        //    }
                        //}

                        //Shooting
                        //if (Movement2.Button2() && !shootButtonHeld) {
                        //    shootProjectile = true;
                        //    xShootLeft = Movement2.Left2();
                        //    xShootRight = Movement2.Right2();
                        //    yShootUp = Movement2.Up2();
                        //    yShootDown = Movement2.Down2();
                        //}
                        //else if (!Movement2.Button2() && shootButtonHeld)
                        //{
                        //    shootButtonHeld = false;
                        //}
                  //  break;
                //}

                //if (xpos > 600) { xpos = 600; }
                //if (ypos > 400) { ypos = 400; }

                //if (ypos > 398) { 
                //    touchedFloor = true;
                //}
                //else
                //{
                //    touchedFloor = false;
                //}
                //Debug.Write(touchedFloor);

                //PlayerSprite.Update(TicksThisLoop);
                PlayerSprite.Position = new Vector2f(xpos, ypos);
                if (shootProjectile && !shootButtonHeld)
                {
                    shootProjectile = false;
                    shootButtonHeld = true;
                    Game.BasicAnimatedSprite bullet = new Game.BasicAnimatedSprite("../../Assets/Sprites/test3.png", 10, 8, 3, 50, false,0);


                    bullet.Direction = ShotDirection;
                    bullet.Position = new Vector2f(xpos + (xShootRight ) - (xShootLeft), ypos + (yShootDown) - (yShootUp));

                    Projectiles.Add(bullet);

                }

                //Play Sound
                //if (xpos > 100 && PlayOnce)
                //{
                //    PlayOnce = false;
                //    BoomNoise.Play();
                //}

                app.Draw(PlayerSprite.Draw());

                foreach (Game.Entity Shot in Projectiles) {
                    Shot.Update(TicksThisLoop);
                    if(Shot.Direction == "Up")
                    {
                        Shot.Position = new Vector2f(Shot.Position.X, Shot.Position.Y - 1);    
                    }
                    if (Shot.Direction == "Down")
                    {
                        Shot.Position = new Vector2f(Shot.Position.X, Shot.Position.Y + 1);
                    }
                    if (Shot.Direction == "Left")
                    {
                        Shot.Position = new Vector2f(Shot.Position.X-1, Shot.Position.Y);
                    }
                    if (Shot.Direction == "Right")
                    {
                        Shot.Position = new Vector2f(Shot.Position.X + 1, Shot.Position.Y );
                    }
                    app.Draw(Shot.Draw());
                }

                // Update the window
                app.Display();

                TotalLoops++;
                TicksThisLoop = Clock.Reset();

            } //End game loop
        } //End Main()
    } //End Program
}
