using System;
using System.Drawing;
using System.Windows.Forms;

//Vic Novosad. C#Level2 - Lesson1
namespace MyGame
{
    class Program
    {
        public static Form form;
        public static int Width = 1440;
        public static int Height = 900;
        public static bool GameStart { get; set; } = false;


        /// <summary>
        /// Point of the entrance
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            form = CreateForm(Width, Height);
            //splashScreen.MaximizeBox = false;
            //SplashScreen.Init(form);
            Game.Init(form);
            //Game.GraphicsInit(form);
            //form.Show();
            //Game.Draw();
            Application.Run(form);
            //Application.Run(new AnimateImage("SunRotation"));
        }

        /// <summary>
        /// Form Creation method with checking of oversizing (not more than 1500px x 1000px)
        /// </summary>
        /// <param name="width"> Width of creating form</param>
        /// <param name="heigth"> Height of creating form</param>
        /// <returns></returns>
        public static Form CreateForm(int width, int heigth)
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Name = "Game";
            form.Text = "Asteroids";

            try
            {
                if (width > 0 && heigth > 0 && width < 1500 && heigth < 1000)
                {
                    form.Width = width;
                    form.Height = heigth;
                }
                else
                    throw new ArgumentOutOfRangeException("The height or width of the screen is out of the range.");

            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
            }

            return form;
        }
    }
}