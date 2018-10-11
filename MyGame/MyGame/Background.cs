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
        public Background(string imageName) : this (new Point(1,1), new Point(1, 1), new Size(1, 1), imageName, "jpg")
        {
        }

        /// <summary>
        /// Background object with upper-left corner of the screen position witout movement
        /// </summary>
        /// <param name="imageName"></param>
        public Background(Point Pos, string imageName, string extension) : this (Pos, new Point(1, 1), new Size(1, 1), imageName, extension)
        {
        }

        /// <summary>
        /// Background object with upper-left corner of the screen position witout movement
        /// </summary>
        /// <param name="imageName"></param>
        public Background(string imageName, string extension) : this (new Point(1,1), new Point(1, 1), new Size(1, 1), imageName, extension)
        {
        }

        /// <summary>
        /// Background object with set parametes
        /// </summary>
        /// <param name="pos">Upper left position of the backgound picture</param>
        /// <param name="dir">Direction of movement the background in a case you would like to make it not static</param>
        /// <param name="size">Size of the picture</param>
        /// <param name="imageName">Image name without file extention (intended use of "jpg" files)</param>
        public Background(Point pos, Point dir, Size size, string imageName, string extension) : base(pos, dir, size)
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
        public override void Draw()
        {
            // Create Point (upper-left corner of image)
            Point ulCorner = Pos;
            // Draw image to screen
            Game.Buffer.Graphics.DrawImage(Img, ulCorner);

        }

        public override void Update()
        {
        }
    }
}
