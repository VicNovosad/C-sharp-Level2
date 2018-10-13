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
        public bool GameStart { get; set; } = false;

        public bool GraphicInit { get; set; } = false;

        private BufferedGraphicsContext Context { get; set; }
        public BufferedGraphics Buffer { get; set; }

        public List<BaseObject> ObjsList { get; set; } = new List<BaseObject>();
        public List<BaseObject> Bullets { get; set; } = new List<BaseObject>();
        public List<BaseObject> Asteroids { get; set; } = new List<BaseObject>();

        public Random rnd = new Random();
        private Timer timer = new Timer();
        public int Width { get; set; }
        public int Height { get; set; }

        #region UI Elements
        public Button StartBtn { get; set; }
        public Button RecordsBtn { get; set; }
        public Button ExitBtn { get; set; }

        public Label Sign { get; set; }


        public Color BackColor { get; set; } = Color.Black; // alternative could be DarkSlateGray
        #endregion

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
        public virtual void Init(Form form)
        {
            timer.Interval = 1;
            timer.Start();
            timer.Tick += Timer_Tick;

            if (GameStart == false)
            {
                //SplashScreen.Init(form);
            }
            else
            {
                ObjsList.Clear();
                timer.Interval = 60;
                Load();
            }
            //ObjsList.Clear();
            //timer.Interval = 60;
            //Game.Load();
        }

        /// <summary>
        /// Graphics Initialization
        /// </summary>
        /// <param name="form"></param>
        public void GraphicsInit(Form form)
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
        public virtual void Timer_Tick(object sender, EventArgs e)
        {

            Draw();
            Update();
        }

        /// <summary>
        /// Method of drawing and rendering graphics
        /// </summary>
        public void Draw()
        {
            // Graphics output
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in ObjsList)
                obj.Draw(this);
            foreach (BaseObject obj in Asteroids)
                obj.Draw(this);
            foreach (BaseObject obj in Bullets)
                obj.Draw(this);
            Buffer.Render();
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public virtual void Update()
        {
            foreach (BaseObject obj in ObjsList)
                obj.Update(this);
            foreach (BaseObject obj in Asteroids)
                obj.Update(this);
            foreach (BaseObject obj in Bullets)
                obj.Update(this);

        }

        #region UI Init
        public Button ButtonInit(string name, Size size, Point loc, Form form, EventHandler handler)
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

        public Label LabelInit(Point loc, Size size, string text, Form form)
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

        public virtual void StartGame(object sender, EventArgs e)
        {
            GameStart = true;
            ObjsList.Clear();
            timer.Interval = 160;
            Load();
        }
        #endregion
        public void RecordDesk(object sender, EventArgs e)
        {
            MessageBox.Show("Your score: 100", "Records", MessageBoxButtons.OK);
        }

        public virtual  void ExitGame(object sender, EventArgs e)
        {
            timer.Stop();
            Application.Exit();
        }


        /// <summary>
        /// Load objects in objsList
        /// </summary>
        public virtual void Load()
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
            ObjsList.Add(new Background("Background", this));
            #endregion

            #region Bullets & Asteroids

            Bullets.Add(new Bullet(new Point(180, Height / 2 - 4), new Point(3, 0), new Size(57, 8), "bullet", this));

            for (int i = 0; i < baseObjQty; i++)
            {
                int r = rnd.Next(5, 50);
                Asteroids.Add(new Asteroid(new Point(600, rnd.Next(0, Height)), new Point(-r / 5, r), new Size(30, 30), "Asteroid2", this));
            }

            #endregion

            #region Circle objects
            for (int i = 0; i < baseObjQty; i++)
            {
                int size = rnd.Next(1, baseObjMaxSize);
                int spdX = rnd.Next(2, baseObjMaxSpeed);
                int spdY = 1;
                ObjsList.Add(new Circle(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), this));
            }
            #endregion

            #region stars
            for (int i = 0; i < starQty; i++)
            {
                int size = rnd.Next(1, starMaxSize);
                int spdX = rnd.Next(2, starMaxSpeed);
                int spdY = 1;
                ObjsList.Add(new Star(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), this));
            }
            #endregion

            #region SpaceObjects
            for (int i = 1; i <= spaceObjQty; i++)
            {
                int size = rnd.Next(1, spaceObjMaxSize);
                int spdX = rnd.Next(2, spaceObjMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new SpaceObjects(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"{rnd.Next(1, spaceObjVariety)}", this));
            }
            #endregion

            #region Planets
            for (int i = 1; i <= planetQty; i++)
            {
                int size = rnd.Next(1, spaceObjMaxSize);
                int spdX = rnd.Next(2, planetMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new Planet(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"Planet{i}", this));
            }
            #endregion

            #region Suns
            for (int i = 1; i <= sunQty; i++)
            {
                int size = rnd.Next(1, sunMaxSize);
                int spdX = rnd.Next(2, sunMaxSpeed);
                int spdY = rnd.Next(1);
                ObjsList.Add(new Sun(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size), $"sun{i}", this));
            }
            #endregion

            #region SpaceShip
            ObjsList.Add(new SpaceShip(new Point(1, Height / 2 - 65), new Point(1, 1), new Size(200, 125), "SpaceShip", this));
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