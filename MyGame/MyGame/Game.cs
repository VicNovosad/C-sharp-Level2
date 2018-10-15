using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class Game
    {
        /// <summary>
        /// Class properties
        /// </summary>
        //public static bool GameStart { get; set; } = false;
        public static bool GraphicInit { get; set; } = false;

        private static BufferedGraphicsContext Context { get; set; }
        public static BufferedGraphics Buffer { get; set; }

        public static List<BaseObject> ObjsList { get; set; } = new List<BaseObject>();
        public static List<BaseObject> Bullets { get; set; } = new List<BaseObject>();
        public static List<BaseObject> Asteroids { get; set; } = new List<BaseObject>();
        //public static List<AnimateImage> RotatingObjects { get; set; } = new List<AnimateImage>();

        private static Random rnd = new Random();
        public static Timer timer = new Timer();
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// Constructor for Game class
        /// </summary>
        public Game()
        {
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            timer.Interval = 1;
            timer.Start();
            timer.Tick += Timer_Tick;
            if (Program.GameStart == false)
            {
                SplashScreen.Init(form);
            }
            else
            {
                ObjsList.Clear();
                timer.Interval = 60;
                Game.Load();
            }

            GraphicsInit(form);
            form.Show();
            Draw();

            //ObjsList.Clear();
            //timer.Interval = 60;
            //Game.Load();
        }

        /// <summary>
        /// Graphics Initialization
        /// </summary>
        /// <param name="form"></param>
        public static void GraphicsInit(Form form)
        {
            if (GraphicInit == false)
            {
                // Create an object (drawing surface) and associate it with a form.
                // Graphic display device
                Graphics Graph;
                // Provides access to the main graphics context buffer for the current application.
                Context = BufferedGraphicsManager.Current;

                Graph = form.CreateGraphics();

                // Link the buffer in memory with the graphic object to draw in the buffer
                Buffer = Context.Allocate(Graph, new Rectangle(0, 0, Width, Height));
                GraphicInit = true;
            }
        }

        /// <summary>
        /// Timer Ticker method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {

            Draw();
            Update();
        }

        /// <summary>
        /// Method of drawing and rendering graphics
        /// </summary>
        public static void Draw()
        {
            // Graphics output
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in ObjsList)
                obj.Draw();
            foreach (BaseObject obj in Asteroids)
                obj.Draw();
            foreach (BaseObject obj in Bullets)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in ObjsList)
                obj.Update();
            foreach (BaseObject a in Asteroids)
            {
                a.Update();
                //foreach (BaseObject b in Bullets)
                for (int i = Bullets.Count - 1; i >= 0; i--)
                {
                    if (a.Collision(Bullets[i]))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        Bullets[i].Pos = Bullets[i].StartPos;
                        Bullets.RemoveAt(i);
                        a.Pos.X = Game.Width;
                        a.Pos.Y = rnd.Next(125, Game.Height - 125);
                    }
                }
            }
            foreach (BaseObject obj in Bullets)
                obj.Update();
        }

        /// <summary>
        /// Load objects in objsList
        /// </summary>
        public static void Load()
        {
            #region Properties (Quantity, Size, Speed)
            int baseObjQty = 10;
            int starQty = 25;
            int spaceObjQty = 10;
            int planetQty = 7;
            int sunQty = 5;

            int baseObjMaxSize = 5;
            int starMaxSize = 5;
            int spaceObjMaxSize = 1;
            int sunMaxSize = 1;

            int baseObjMaxSpeed = 4;
            int starMaxSpeed = 3;
            int spaceObjMaxSpeed = 6;
            int planetMaxSpeed = 7;
            int sunMaxSpeed = 7;

            int spaceObjVariety = 10; //quantity of space objects pictures
            #endregion

            #region Background
            ObjsList.Add(new Background("Background"));
            #endregion

            //RotatingObjects.Add(new AnimateImage("SunRotation"));
            
            #region Bullets & Asteroids

            Bullets.Add(new Bullet(new Point(180, Height / 2 - 4), new Point(3, 0), new Size(57, 8), "bullet"));

            for (int i = 0; i < baseObjQty; i++)
            {
                //int dirX = rnd.Next(5, 50);
                //int dirY = rnd.Next(-1, 1);
                //Asteroids.Add(new Asteroid(new Point(rnd.Next(Game.Width - 30, Game.Width + 50), rnd.Next(125, Game.Height - 125)), new Point(-dirX / 5, dirY), new Size(30, 30), "Asteroid2"));

                Asteroids.Add(new Asteroid(new Size(30, 30), rnd.Next(1, 10)));
            }

            #endregion

            #region Circle objects
            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(2, baseObjMaxSpeed);
                int spdY = 1;
                ObjsList.Add(new Circle(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size)));
            }
            #endregion

            #region stars
            for (int i = 0; i < starQty; i++)
            {
                int size = rnd.Next(1, starMaxSize);
                int spdX = rnd.Next(2, starMaxSpeed);
                int spdY = 1;
                ObjsList.Add(new Star(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size)));
            }
            #endregion

            #region SpaceObjects
            for (int i = 1; i <= spaceObjQty; i++)
            {
                int size = rnd.Next(1, spaceObjMaxSize);
                int spdX = rnd.Next(2, spaceObjMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new SpaceObjects(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"{rnd.Next(1, spaceObjVariety)}"));
            }
            #endregion

            #region Planets
            for (int i = 1; i <= planetQty; i++)
            {
                int size = rnd.Next(1, spaceObjMaxSize);
                int spdX = rnd.Next(2, planetMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new Planet(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"Planet{i}"));
            }
            #endregion

            #region Suns
            for (int i = 1; i <= sunQty; i++)
            {
                int size = rnd.Next(1, sunMaxSize);
                int spdX = rnd.Next(2, sunMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new Sun(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"sun{i}"));
            }
            #endregion

            #region SpaceShip
            ObjsList.Add(new SpaceShip(new Point(1, Height / 2 - 65), new Point(1, 1), new Size(200, 125), "SpaceShip"));
            #endregion
        }

        //private void CheckPosition()
        //{
        //    for (var i = 0; i < Game.Asteroids.Count; i++)
        //    {
        //        if (TakenPlace.IntersectsWith(Game.Asteroids[i].TakenPlace))
        //        {
        //            Pos = StartPos;
        //            Game.Asteroids[i].Pos.X = rnd.Next(200, Game.Width);
        //            Game.Asteroids[i].Pos.Y = 0;
        //            break;
        //        }
        //    }
        //}


    }
}