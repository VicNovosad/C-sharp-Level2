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
            int screenWidth = 1440;
            int screenHeight = 900;

            Form splashScreen = new Form();
            splashScreen.Width = screenWidth;
            splashScreen.Height = screenHeight;
            splashScreen.StartPosition = FormStartPosition.CenterScreen;
            //splashScreen.MaximizeBox = false;
            SplashScreen.Init(splashScreen);
            SplashScreen.AddButton(splashScreen);
            splashScreen.Show();

            Application.Run(splashScreen);

            Form form = new Form();
            form.Name = "Game";
            form.Text = "Asteroids";
            form.Width = screenWidth;
            form.Height = screenHeight;
            form.StartPosition = FormStartPosition.CenterScreen;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}