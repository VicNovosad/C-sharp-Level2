using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    class SplashScreen
    {
        /// <summary>
        /// Class properties
        /// </summary>
        public static BufferedGraphicsContext Context { get; set; }
        public static BufferedGraphics Buffer { get; set; }

        public static List<BaseObject> ObjsList { get; set; } = new List<BaseObject>();
        //private static Backpic Back { get; set; }
        //private static Image Img { get; set; }


        //private static Random rnd = new Random();

        #region properties
        public static int Width { get; set; }
        public static int Height { get; set; }

        private static Color BackColor { get; set; } = Color.Black;
        #endregion

        /// <summary>
        /// Constructor for static fields
        /// </summary>
        static SplashScreen()
        {            
        }

        #region UI Elements
        private static Button startBtn;
        private static Button recordsBtn;
        private static Button exitBtn;

        static Label sign;

        //public static void AddButton(Form form)
        //{
        //    startBtn.Location = new Point(Width - 200, 50);
        //    startBtn.Size = new Size(150, 50);
        //    startBtn.TabIndex = 0;
        //    startBtn.Text = "Start";
        //    startBtn.UseVisualStyleBackColor = true;
        //    startBtn.BackColor = Color.DarkGray;
        //    startBtn.TextAlign = ContentAlignment.MiddleCenter;
        //    startBtn.ForeColor = Color.White;
        //    startBtn.Font = new Font("Arial", 20, FontStyle.Regular);
        //    startBtn.Click += StartBtn_Click;
        //    form.Controls.Add(startBtn);

        //    recordsBtn.Location = new Point(Width - 200, 150);
        //    recordsBtn.Size = new Size(150, 50);
        //    recordsBtn.TabIndex = 0;
        //    recordsBtn.Text = "Record";
        //    recordsBtn.UseVisualStyleBackColor = true;
        //    recordsBtn.BackColor = Color.DarkGray;
        //    recordsBtn.TextAlign = ContentAlignment.MiddleCenter;
        //    recordsBtn.ForeColor = Color.White;
        //    recordsBtn.Font = new Font("Arial", 20, FontStyle.Regular);
        //    recordsBtn.Click += RecordsBtn_Click;
        //    form.Controls.Add(recordsBtn);

        //    exitBtn.Location = new Point(Width - 200, 250);
        //    exitBtn.Size = new Size(150, 50);
        //    exitBtn.TabIndex = 0;
        //    exitBtn.Text = "Exit";
        //    exitBtn.UseVisualStyleBackColor = true;
        //    exitBtn.BackColor = Color.DarkGray;
        //    exitBtn.TextAlign = ContentAlignment.MiddleCenter;
        //    exitBtn.ForeColor = Color.White;
        //    exitBtn.Font = new Font("Arial", 20, FontStyle.Regular);
        //    exitBtn.Click += ExitBtn_Click;
        //    form.Controls.Add(exitBtn);
        //}

        //private static void StartBtn_Click(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("Start (need to close currnt form)");

        //    Buffer.Graphics.Clear(Color.Black);
        //    Form.ActiveForm.Enabled = false;
        //    Form.ActiveForm.Visible = false;
        //    //Form.ActiveForm.Close();

        //    Form form = new Form();
        //    form.Name = "Game";
        //    form.Text = "Asteroids";
        //    form.Width = Width;
        //    form.Height = Height;
        //    form.StartPosition = FormStartPosition.CenterScreen;
        //    Game.Init(form);
        //    form.Show();
        //    Game.Draw();

        //}
        //private static void RecordsBtn_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Records results");
        //}
        //private static void ExitBtn_Click(object sender, EventArgs e)
        //{
        //    if (Application.MessageLoop) Application.Exit(); else Environment.Exit(1);
        //}
        #endregion

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            form.BackColor = System.Drawing.Color.Black;

            Size btnSize = new Size(290, 46);
            Point center = new Point(form.Width / 2, form.Height / 2);
            Size textSize = new Size(250, 46);

            startBtn = ButtonInit("Start", btnSize, new Point(Width - btnSize.Width - 10, 15), form, new EventHandler(StartGame));
            recordsBtn = ButtonInit("Record", btnSize, new Point(Width - btnSize.Width - 10, btnSize.Height + 25), form, new EventHandler(RecordDesk));
            exitBtn = ButtonInit("Exit", btnSize, new Point(Width - btnSize.Width - 10, btnSize.Height * 2 + 35), form, new EventHandler(ExitGame));

            //sign = LabelInit(new Point(center.X - btnSize.Width / 2, center.Y + 350), btnSize, "(c) 2018 created by Vic Novosad", form);
            sign = LabelInit(new Point(Width - textSize.Width, Height - textSize.Height - 10), btnSize, "2018, created by Vic Novosad", form);

            // Create an object (drawing surface) and associate it with a form.
            // Graphic display device
            Graphics g;

            // Provides access to the main graphics context buffer for the current application.
            Context = BufferedGraphicsManager.Current;

            g = form.CreateGraphics();
            
            // Link the buffer in memory with the graphic object to draw in the buffer
            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Game.Init(Program.form);
            Game.Draw();

            //Timer timer = new Timer { Interval = 1000 };
            //timer.Start();
            //timer.Tick += Timer_Tick;
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
        /// Button initialisation
        /// </summary>
        /// <param name="name"> Text </param>
        /// <param name="size"> Size </param>
        /// <param name="loc"> </param>
        /// <param name="form"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private static Button ButtonInit(string name, Size size, Point loc, Form form, EventHandler handler)
        {
            Button but = new Button();
            but.Text = name;
            but.Size = size;
            but.Location = loc;
            but.Click += handler;
            form.Controls.Add(but);
            Image img = Image.FromFile($"..\\..\\button.png");
               
            but.Image = (Image)(new Bitmap(img, size));

            return but;

            //startBtn.Location = new Point(Width - 200, 50);
            //startBtn.TabIndex = 0;
            //startBtn.UseVisualStyleBackColor = true;
            //startBtn.BackColor = Color.DarkGray;
            //startBtn.TextAlign = ContentAlignment.MiddleCenter;
            //startBtn.ForeColor = Color.White;
            //startBtn.Font = new Font("Arial", 20, FontStyle.Regular);
            //startBtn.Click += StartBtn_Click;
            //form.Controls.Add(startBtn);

        }

        private static Label LabelInit(Point loc, Size size, string text, Form form)
        {
            Label label = new Label();
            label.Location = loc;
            label.Size = size;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.ForeColor = Color.White;
            label.BackColor = BackColor;
            form.Controls.Add(label);

            return label;

        }

        private static void StartGame(object sender, EventArgs e)
        {
            //Program.FormNumber = 2;
            //Program.form.Controls.Clear();
            Game.Init(Program.form);
            Game.Draw();

            Timer timer = new Timer { Interval = 1000 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void RecordDesk(object sender, EventArgs e)
        {
            MessageBox.Show("Тут будут рекорды", "Рекорды", MessageBoxButtons.OK);
        }

        private static void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Method of drawing and rendering graphics
        /// </summary>
        public static void Draw()
        {
            // Graphics output
            //foreach (BaseObject obj in ObjsList)
            //    obj.Draw();
            //Buffer.Graphics.Clear(BackColor);
            //Back.Draw();
            //Buffer.Render();
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public static void Update()
        {
            //foreach (BaseObject obj in ObjsList)
            //    obj.Update();
        }

        public static void Load()
        {
            // Background picture
            //Back = new Backpic("Background2");
        }
    }
}
