using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class SplashScreen : Game
    {
        //private Random rnd = new Random();

        /// <summary>
        /// Constructor for SplashScreen
        /// </summary>
        public SplashScreen()
        {
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public override void Init(Form form)
        {
            #region add UI elements on the form
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            form.BackColor = BackColor;

            Size btnSize = new Size(290, 46);
            Point btnsPos = new Point(Width - btnSize.Width - 20, Height - btnSize.Height - 25);
            Size textSize = new Size(160, 30);

            StartBtn = ButtonInit("Start", btnSize, new Point(btnsPos.X, btnsPos.Y - btnSize.Height * 2 - 20), form, new EventHandler(StartGame));
            RecordsBtn = ButtonInit("Record", btnSize, new Point(btnsPos.X, btnsPos.Y - btnSize.Height - 10), form, new EventHandler(RecordDesk));
            ExitBtn = ButtonInit("Exit", btnSize, btnsPos, form, new EventHandler(ExitGame));

            //sign = LabelInit(new Point(center.X - btnSize.Width / 2, center.Y + 350), btnSize, "(c) 2018 created by Vic Novosad", form);
            Sign = LabelInit(new Point(20, Height - textSize.Height - 10), textSize, "2018, created by Vic Novosad", form);
            #endregion

            Load(form);
        }

        /// <summary>
        /// Method of drawing and rendering graphics
        /// </summary>
        //public void Draw()
        //{
        //}

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public override void Update()
        {
            foreach (BaseObject obj in ObjsList)
                obj.Update(this);
        }

        public void Load(Form form)
        {
            #region region properties
            int baseObjQty = 40;
            int starQty = 60;
            //int spaceObjQty = 20;
            //int planetQty = 7;
            //int sunQty = 5;

            int baseObjMaxSize = 5;
            int starMaxSize = 5;
            //int spaceObjMaxSize = 6;
            //int sunMaxSize = 6;

            int baseObjMaxSpeed = 5;
            int starMaxSpeed = 7;
            //int spaceObjMaxSpeed = 10;
            //int planetMaxSpeed = 6;
            //int sunMaxSpeed = 5;

            //int spaceObjVariety = 10; //quantity of space objects pictures
            #endregion

            #region Background
            ObjsList.Add(new Background("Background2", this));
            #endregion

            #region base objects
            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(1, baseObjMaxSpeed);
                int spdY = rnd.Next(1, baseObjMaxSpeed);
                ObjsList.Add(new Circle(new Point(rnd.Next(320, 325), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size), 1, this));
            }
            #endregion

            #region stars
            for (int i = 0; i < starQty; i++)
            {
                int size = rnd.Next(1, starMaxSize);
                int spdX = rnd.Next(1, starMaxSpeed);
                int spdY = rnd.Next(1, starMaxSpeed);
                ObjsList.Add(new Star(new Point(rnd.Next(320, 325), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size), this));
            }
            #endregion

            #region StarShip
            ObjsList.Add(new Background(new Point(705, 460), "StarShip", "png", this));
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
