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
        private static Color BackColor { get; set; } = Color.Black; // DarkSlateGray

        private static Random rnd = new Random();

        private static bool GameStart { get; set; } = false;

        /// <summary>
        /// Constructor for static fields
        /// </summary>
        static Game()
        {
        }

        #region UI Elements
        private static Button startBtn;
        private static Button recordsBtn;
        private static Button exitBtn;

        static Label sign;
        #endregion



        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            #region add UI elements on the form
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            form.BackColor = BackColor;

            Size btnSize = new Size(290, 46);
            Point center = new Point(form.Width / 2, form.Height / 2);
            Size textSize = new Size(160, 30);

            startBtn = ButtonInit("Start", btnSize, new Point(Width - btnSize.Width - 20, Height - btnSize.Height * 3 - 45), form, new EventHandler(StartGame));
            recordsBtn = ButtonInit("Record", btnSize, new Point(Width - btnSize.Width - 20, Height - btnSize.Height * 2 - 35), form, new EventHandler(RecordDesk));
            exitBtn = ButtonInit("Exit", btnSize, new Point(Width - btnSize.Width - 20, Height - btnSize.Height - 25), form, new EventHandler(ExitGame));

            //sign = LabelInit(new Point(center.X - btnSize.Width / 2, center.Y + 350), btnSize, "(c) 2018 created by Vic Novosad", form);
            sign = LabelInit(new Point(20, Height - textSize.Height - 10), textSize, "2018, created by Vic Novosad", form);
            #endregion

            // Create an object (drawing surface) and associate it with a form.
            // Graphic display device
            Graphics g;

            // Provides access to the main graphics context buffer for the current application.
            Context = BufferedGraphicsManager.Current;
            
            g = form.CreateGraphics();

            // Remember the size of the form
            Width = form.Width;
            Height = form.Height;


            // Link the buffer in memory with the graphic object to draw in the buffer
            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            if (GameStart == true)
            {
                timer.Interval = 60;
                Load();
            }
            else PreLoad();


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
            #region region properties
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
            #endregion

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

        public static void PreLoad()
        {
            #region region properties
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
            #endregion

            #region Background
            ObjsList.Add(new Background(new Point(1, 1), new Point(1, 1), new Size(1, 1), "Background2"));
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

            //#region stars
            //for (int i = 0; i < starQty; i++)
            //{
            //    int size = rnd.Next(1, starMaxSize);
            //    int spdX = rnd.Next(2, starMaxSpeed);
            //    int spdY = 1;
            //    ObjsList.Add(new Star(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size)));
            //}
            //#endregion

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
            //Program.FormNumber = 2;
            //Program.form.Controls.Clear();
            GameStart = true;

            ObjsList.Clear();
            Game.Init(Program.form);
            Game.Draw();

            //Timer timer = new Timer { Interval = 100 };
            //timer.Start();
            //timer.Tick += Timer_Tick;
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