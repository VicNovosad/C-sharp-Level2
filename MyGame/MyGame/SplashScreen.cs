using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class SplashScreen
    {
        private static Random rnd = new Random();

        #region UI Elements
        private static Button startBtn;
        private static Button recordsBtn;
        private static Button exitBtn;

        static Label sign;


        private static Color BackColor { get; set; } = Color.Black; // alternative could be DarkSlateGray
        #endregion

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
        public static void Init(Form form)
        {
            #region add UI elements on the form
            Game.Width = form.ClientSize.Width;
            Game.Height = form.ClientSize.Height;

            form.BackColor = BackColor;

            Size btnSize = new Size(290, 46);
            Point btnsPos = new Point(Game.Width - btnSize.Width - 20, Game.Height - btnSize.Height - 25);
            Size textSize = new Size(160, 30);

            startBtn = ButtonInit("Start", btnSize, new Point(btnsPos.X, btnsPos.Y - btnSize.Height * 2 - 20), form, new EventHandler(StartGame));
            recordsBtn = ButtonInit("Record", btnSize, new Point(btnsPos.X, btnsPos.Y - btnSize.Height - 10), form, new EventHandler(RecordDesk));
            exitBtn = ButtonInit("Exit", btnSize, btnsPos, form, new EventHandler(ExitGame));

            //sign = LabelInit(new Point(center.X - btnSize.Width / 2, center.Y + 350), btnSize, "(c) 2018 created by Vic Novosad", form);
            sign = LabelInit(new Point(20, Game.Height - textSize.Height - 10), textSize, "2018, created by Vic Novosad", form);
            #endregion

            Load(form);
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
            foreach (BaseObject obj in Game.ObjsList)
                obj.Update();
        }

        public static void Load(Form form)
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
            Game.ObjsList.Add(new Background("Background2"));
            #endregion

            #region base objects
            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(1, baseObjMaxSpeed);
                int spdY = rnd.Next(1, baseObjMaxSpeed);
                Game.ObjsList.Add(new Circle(new Point(rnd.Next(320, 325), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size), 1));
            }
            #endregion

            #region stars
            for (int i = 0; i < starQty; i++)
            {
                int size = rnd.Next(1, starMaxSize);
                int spdX = rnd.Next(1, starMaxSpeed);
                int spdY = rnd.Next(1, starMaxSpeed);
                Game.ObjsList.Add(new Star(new Point(rnd.Next(320, 325), rnd.Next(215, 225)), new Point(spdX, spdY), new Size(size, size)));
            }
            #endregion

            #region StarShip
            Game.ObjsList.Add(new Background(new Point(705, 460), "StarShip", "png"));
            #endregion

            //#region SpaceObjects
            //for (int i = 1; i <= spaceObjQty; i++)
            //{
            //    int size = rnd.Next(1, spaceObjMaxSize);
            //    int spdX = rnd.Next(2, spaceObjMaxSpeed);
            //    int spdY = rnd.Next(1);
            //    Game.ObjsList.Add(new SpaceObjects(new Point(rnd.Next(1, Game.Width), rnd.Next(1, Game.Height)), new Point(spdX, spdY), new Size(size, size), $"{rnd.Next(1, spaceObjVariety)}"));
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


        private static Button ButtonInit(string name, Size size, Point loc, Form form, EventHandler handler)
        {
            Color fc = Color.FromArgb(255, 103, 168, 178);
            Color bc = Color.FromArgb(220, 7, 24, 40);
            Color moc = Color.FromArgb(220, 43, 24, 56);
            Color mdc = Color.FromArgb(220, 79, 41, 105);

            Button btn = new Button();
            btn.Text = name;
            btn.Size = size;
            //but.UseVisualStyleBackColor = true;

            //but.ForeColor = fc;
            //but.BackColor = bc;
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = fc; //font and frame
            btn.BackColor = bc; //button color can be also /*Color.Transparent*/
            btn.FlatAppearance.MouseOverBackColor = moc;
            btn.FlatAppearance.MouseDownBackColor = mdc;
            //btn.FlatAppearance.BorderSize = 1;

            //but.ForeColor = Color.Black;
            btn.Font = new Font("Arial", 15, FontStyle.Regular);
            btn.Location = loc;
            btn.Click += handler;
            form.Controls.Add(btn);
            Image img = Image.FromFile($"..\\..\\button.png");
            btn.Image = (Image)(new Bitmap(img, size));

            return btn;
            //form.Controls.Add(startBtn);
        }

        private static Label LabelInit(Point loc, Size size, string text, Form form)
        {
            Color fc = Color.FromArgb(255, 103, 168, 178);
            Color bc = Color.FromArgb(5, 13, 6, 14);

            Label label = new Label();
            label.Location = loc;
            label.Size = size;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = fc;
            label.Font = new Font("Arial", 8, FontStyle.Bold);
            label.BackColor = Color.Transparent;
            form.Controls.Add(label);

            return label;

        }

        private static void StartGame(object sender, EventArgs e)
        {
            Game.GameStart = true;
            Game.ObjsList.Clear();
            Game.timer.Interval = 60;
            Game.Load();
        }

        private static void RecordDesk(object sender, EventArgs e)
        {
            MessageBox.Show("Your score: 100", "Records", MessageBoxButtons.OK);
        }

        private static void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
