using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{


    class SplashScreen
    {
        public static List<BaseObject> ObjsList { get; set; } = new List<BaseObject>();

        private static Random rnd = new Random();
        private static Timer timer = new Timer();


        /// <summary>
        /// Constructor for SplashScreen
        /// </summary>
        public SplashScreen(Form form)
        {
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public void Init(Form form)
        {
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
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public static void Update()
        {
        }

        public static void Load()
        {
            #region region properties
            int baseObjQty = 20;
            int starQty = 40;
            int spaceObjQty = 20;
            int planetQty = 7;
            int sunQty = 5;

            int baseObjMaxSize = 5;
            int starMaxSize = 5;
            int spaceObjMaxSize = 6;
            int sunMaxSize = 6;

            int baseObjMaxSpeed = 5;
            int starMaxSpeed = 7;
            int spaceObjMaxSpeed = 10;
            int planetMaxSpeed = 6;
            int sunMaxSpeed = 5;

            int spaceObjVariety = 10; //quantity of space objects pictures
            #endregion

            #region Background
            ObjsList.Add(new Background("Background2"));
            #endregion

            #region base objects
            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(1, baseObjMaxSpeed);
                int spdY = rnd.Next(1, baseObjMaxSpeed);
                ObjsList.Add(new BaseObject(new Point(rnd.Next(290, 300), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size)));
            }
            #endregion

            #region stars
            for (int i = 0; i < starQty; i++)
            {
                int size = rnd.Next(1, starMaxSize);
                int spdX = rnd.Next(1, starMaxSpeed);
                int spdY = rnd.Next(1, starMaxSpeed);
                ObjsList.Add(new Star(new Point(rnd.Next(290, 300), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size)));
            }
            #endregion

            #region StarShip
            ObjsList.Add(new Background(new Point(705, 460), "StarShip", "png"));
            #endregion

            //#region SpaceObjects
            //for (int i = 1; i <= spaceObjQty; i++)
            //{
            //    int size = rnd.Next(1, spaceObjMaxSize);
            //    int spdX = rnd.Next(2, spaceObjMaxSpeed);
            //    int spdY = rnd.Next(1);
            //    ObjsList.Add(new SpaceObjects(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"{rnd.Next(1, spaceObjVariety)}"));
            //}
            //#endregion

            //#region Planets
            //for (int i = 1; i <= planetQty; i++)
            //{
            //    int size = rnd.Next(1, spaceObjMaxSize);
            //    int spdX = rnd.Next(2, planetMaxSpeed);
            //    int spdY = rnd.Next(1);
            //    ObjsList.Add(new Planet(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"Planet{i}"));
            //}
            //#endregion

            //#region Suns
            //for (int i = 1; i <= sunQty; i++)
            //{
            //    int size = rnd.Next(1, sunMaxSize);
            //    int spdX = rnd.Next(2, sunMaxSpeed);
            //    int spdY = rnd.Next(1);
            //    ObjsList.Add(new Sun(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"sun{i}"));
            //}
            //#endregion

            //#region SpaceShip
            //ObjsList.Add(new SpaceShip(new Point(1, Height / 2 - 65), new Point(1, 1), new Size(1, 1), "SpaceShip"));
            //#endregion
        }
    }
}
