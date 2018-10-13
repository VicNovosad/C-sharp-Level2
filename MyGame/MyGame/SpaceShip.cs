using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class SpaceShip
    /// </summary>
    class SpaceShip : BaseObject
    {
        private int shipStage = 0;
        private const int imgQty = 4; // Quantity of sprites
        private Image[] ImgArr { get; set; } = new Image[imgQty];

        /// <summary>
        /// SpaceShip object constructor
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="dir">Direction of the object (Speed and direction)</param>
        /// <param name="size">Size of the object</param>
        /// <param name="imageName"></param>
        public SpaceShip(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            try
            {
                // Creating an image
                for (int i = 0; i < imgQty; i++)
                {
                    ImgArr[i] = Image.FromFile($"..\\..\\{imageName}" + $"{i}" + ".png");
                }
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
            Size.Height = ImgArr[0].Height;
            Size.Width = ImgArr[0].Width;
            TakenPlace = new RectangleF(Pos, Size);
            // Draw image to screen
            Game.Buffer.Graphics.DrawImage(ImgArr[shipStage], TakenPlace);

        }

        /// <summary>
        /// Update of the current object
        /// </summary>
        public override void Update()
        {
            if (shipStage < 3) shipStage++;
            else shipStage = 0;
        }
    }
}

