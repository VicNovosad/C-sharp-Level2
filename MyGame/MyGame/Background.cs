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
        private Image Img { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">Upper left position of the backgound picture</param>
        /// <param name="dir">Direction of movement the background in a case you would like to make it not static</param>
        /// <param name="size">Size of the picture</param>
        /// <param name="imageName">Image name without file extention (intended use of "jpg" files)</param>
        public Background(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            this.imageName = imageName;

            try
            {
                // Creating an image
                Img = Image.FromFile($"..\\..\\{imageName}.jpg");
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
            Point ulCorner = Position;
            // Draw image to screen
            Game.Buffer.Graphics.DrawImage(Img, ulCorner);
        }

        /// <summary>
        /// Update of the current object
        /// </summary>
        public override void Update()
        {
        }
    }
}
