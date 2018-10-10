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
        private string imageName;
        private int shipStage = 0;
        private const int imgQty = 4; // Quantity of SpaceShip sprites
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
            this.imageName = imageName;
            try
            {
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
            // Draw image to screen
            Game.Buffer.Graphics.DrawImage(ImgArr[shipStage], Pos);
        }

        /// <summary>
        /// Update of the current object
        /// </summary>
        public override void Update()
        {
            shipStage = (shipStage < 3) ? shipStage++ : 0;
            Pos.X++;
        }
    }
}
