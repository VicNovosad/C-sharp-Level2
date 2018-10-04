using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class SpaceShip : BaseObject
    {
        private string imageName;

        public SpaceShip(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            this.imageName = imageName;
        }


        public override void Draw()
        {
            try
            {
                // Creating an image
                Image newImage = Image.FromFile($"..\\..\\{imageName}.png");

                // Create Point (upper-left corner of image)
                Point ulCorner = Pos;

                // Draw image to screen
                Game.Buffer.Graphics.DrawImage(newImage, ulCorner);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public override void Update()
        {
            //Pos.X = Pos.X - Dir.X;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
