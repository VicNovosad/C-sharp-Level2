using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        /// <summary>
        /// Class properties
        /// </summary>
        private static BufferedGraphicsContext Context { get; set; }
        public static BufferedGraphics Buffer { get; set; }

        private static List<BaseObject> ObjsList { get; set; } = new List<BaseObject>();
        private static List<BaseObject> BulletList { get; set; } = new List<BaseObject>();
        private static List<BaseObject> AsteroidList { get; set; } = new List<BaseObject>();


        public static int Width { get; set; }
        public static int Height { get; set; }

        private static Random rnd = new Random();

        /// <summary>
        /// Constructor for static fields
        /// </summary>
        static Game()
        {
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Create an object (drawing surface) and associate it with a form.
            #region size of the graphics form
            // Remember the size of the form
            //Width = form.Width;
            //Height = form.Height;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            #endregion
            Load();

            Graphics g; // Graphic display device
            Context = BufferedGraphicsManager.Current; // Provides access to the main graphics context buffer for the current application.
            g = form.CreateGraphics();

            // Link the buffer in memory with the graphic object to draw in the buffer
            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick;
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
            Buffer.Render();
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in ObjsList)
                obj.Update();
        }

        /// <summary>
        /// Load objects in objsList
        /// </summary>
        public static void Load()
        {
            int baseObjQty = 10;
            int starQty = 20;
            int spaceObjQty = 20;
            int planetQty = 7;
            int sunQty = 5;

            int baseObjMaxSize = 5;
            int starMaxSize = 5;
            int spaceObjMaxSize = 6;
            int sunMaxSize = 6;

            int baseObjMaxSpeed = 5;
            int starMaxSpeed = 3;
            int spaceObjMaxSpeed = 6;
            int planetMaxSpeed = 6;
            int sunMaxSpeed = 5;

            int spaceObjVariety = 10; //quantity of space objects pictures

            #region Background
            ObjsList.Add(new Background(new Point(1, 1), new Point(1, 1), new Size(1, 1), "Background"));
            #endregion

            #region base objects

            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(2, baseObjMaxSpeed);
                int spdY = 1;
                ObjsList.Add(new BaseObject(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size)));
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
            ObjsList.Add(new SpaceShip(new Point(1, Height / 2 - 65), new Point(1, 1), new Size(1, 1), "SpaceShip"));
            #endregion
        }
    }
}