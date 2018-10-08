using System;
using System.Windows.Forms;

//Vic Novosad. C#Level2 - Lesson1
namespace MyGame
{
    class Program
    {
        /// <summary>
        /// Point of the entrance
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int Width = 1440;
            int Height = 900;

            Form splashScreen = new Form();
            splashScreen.Width = Width;
            splashScreen.Height = Height;
            splashScreen.StartPosition = FormStartPosition.CenterScreen;
            //splashScreen.MaximizeBox = false;
            SplashScreen.Init(splashScreen);
            SplashScreen.AddButton(splashScreen);
            splashScreen.Show();
            Application.Run(splashScreen);

            #region old call game form
            //Form form = new Form();
            //form.Name = "Game";
            //form.Text = "Asteroids";
            //form.Width = Width;
            //form.Height = Height;
            //form.StartPosition = FormStartPosition.CenterScreen;
            //Game.Init(form);
            //form.Show();
            //Game.Draw();
            //Application.Run(form);
            #endregion
        }
    }
}