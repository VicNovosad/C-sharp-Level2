using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class Backgound
    /// </summary>
    class Background : BaseObject
    {
        private string imageName;
        private Point position = new Point(1, 1);
        //private Image Img { get; set; }

        /// <summary>
        /// Background object with upper-left corner of the screen position witout movement
        /// </summary>
        /// <param name="imageName"></param>
        public Background(string imageName, Game game) : this (new Point(1,1), new Point(1, 1), new Size(1, 1), imageName, "jpg", game)
        {
        }

        /// <summary>
        /// Background object with upper-left corner of the screen position witout movement
        /// </summary>
        /// <param name="imageName"></param>
        public Background(Point Pos, string imageName, string extension, Game game) : this (Pos, new Point(1, 1), new Size(1, 1), imageName, extension, game)
        {
        }

        /// <summary>
        /// Background object with upper-left corner of the screen position witout movement
        /// </summary>
        /// <param name="imageName"></param>
        public Background(string imageName, string extension, Game game) : this (new Point(1,1), new Point(1, 1), new Size(1, 1), imageName, extension, game)
        {
        }

        /// <summary>
        /// Background object with set parametes
        /// </summary>
        /// <param name="pos">Upper left position of the backgound picture</param>
        /// <param name="dir">Direction of movement the background in a case you would like to make it not static</param>
        /// <param name="size">Size of the picture</param>
        /// <param name="imageName">Image name without file extention (intended use of "jpg" files)</param>
        public Background(Point pos, Point dir, Size size, string imageName, string extension, Game game) : base(pos, dir, size, game)
        {
            this.imageName = imageName;

            try
            {
                // Creating an image
                Img = Image.FromFile($"..\\..\\{imageName}.{extension}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Draw of the current object
        /// </summary>
        public override void Draw(Game game)
        {
            Size.Height = Img.Height;
            Size.Width = Img.Width;
            TakenPlace = new RectangleF(Pos, Size);
            // Draw image to screen
            game.Buffer.Graphics.DrawImage(Img, TakenPlace);
        }

        public override void Update(Game game)
        {
        }
    }
}
