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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static List<BaseObject> objsList = new List<BaseObject>();

        public static int Width { get; set; }
        public static int Height { get; set; }

        private static bool gameStarted = false;
        private static Random rnd = new Random();

        /// <summary>
        /// Constructor for static fields
        /// </summary>
        static SplashScreen()
        {            
        }

        #region splash form buttons
        private static Button startBtn = new Button();
        private static Button recordsBtn = new Button();
        private static Button exitBtn = new Button();

        public static void AddButton(Form form)
        {
            startBtn.Location = new Point(Width - 200, 50);
            startBtn.Size = new Size(150, 50);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.BackColor = Color.DarkGray;
            startBtn.TextAlign = ContentAlignment.MiddleCenter;
            startBtn.ForeColor = Color.White;
            startBtn.Font = new Font("Arial", 20, FontStyle.Regular);
            startBtn.Click += StartBtn_Click;
            form.Controls.Add(startBtn);

            recordsBtn.Location = new Point(Width - 200, 150);
            recordsBtn.Size = new Size(150, 50);
            recordsBtn.TabIndex = 0;
            recordsBtn.Text = "Record";
            recordsBtn.UseVisualStyleBackColor = true;
            recordsBtn.BackColor = Color.DarkGray;
            recordsBtn.TextAlign = ContentAlignment.MiddleCenter;
            recordsBtn.ForeColor = Color.White;
            recordsBtn.Font = new Font("Arial", 20, FontStyle.Regular);
            recordsBtn.Click += RecordsBtn_Click;
            form.Controls.Add(recordsBtn);

            exitBtn.Location = new Point(Width - 200, 250);
            exitBtn.Size = new Size(150, 50);
            exitBtn.TabIndex = 0;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.BackColor = Color.DarkGray;
            exitBtn.TextAlign = ContentAlignment.MiddleCenter;
            exitBtn.ForeColor = Color.White;
            exitBtn.Font = new Font("Arial", 20, FontStyle.Regular);
            exitBtn.Click += ExitBtn_Click;
            form.Controls.Add(exitBtn);
        }

        private static void StartBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start (need to close currnt form)");
        }
        private static void RecordsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Records results");
        }
        private static void ExitBtn_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop) Application.Exit(); else Environment.Exit(1);
        }
        #endregion

        private static void CloseCurrentForm(Form form)
        {
            form.Close();
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Create an object (drawing surface) and associate it with a form.
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Load();

            Graphics g; // Graphic display device
            _context = BufferedGraphicsManager.Current; // Provides access to the main graphics context buffer for the current application.
            g = form.CreateGraphics();

            // Link the buffer in memory with the graphic object to draw in the buffer
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
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
            //Update();
        }

        /// <summary>
        /// Method of drawing and rendering graphics
        /// </summary>
        public static void Draw()
        {
            // Graphics output
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objsList)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Updating all graphics objects in objsList
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in objsList)
                obj.Update();
        }

        public static void Load()
        {
            #region Background
            objsList.Add(new Background(new Point(1, 1), new Point(1, 1), new Size(1, 1), "Background2"));
            #endregion

            #region base objects

            //for (int i = 0; i < baseObjQty; i++)
            //{
            //    int size = rnd.Next(1, baseObjMaxSize);
            //    int spdX = rnd.Next(2, baseObjMaxSpeed);
            //    int spdY = 1;
            //    objsList.Add(new BaseObject(new Point(rnd.Next(1, Width), rnd.Next(1, Height)), new Point(spdX, spdY), new Size(size, size)));
            //}
            #endregion

        }

    }
}
