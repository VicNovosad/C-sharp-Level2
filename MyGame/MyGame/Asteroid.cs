using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public Asteroid(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            Power = 1;
            try
            {
                Img = Image.FromFile($"..\\..\\{imageName}.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Draw()
        {
            TakenPlace = new RectangleF(Pos, Size);
            Game.Buffer.Graphics.FillEllipse(Brushes.White, TakenPlace);
            //Game.Buffer.Graphics.DrawImage(Img, TakenPlace);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            if (Pos.X > Game.Width) Pos.X = Game.Width - Size.Width;
            if (Pos.Y < 0) Pos.Y = Game.Height;
            if (Pos.Y > Game.Height) Pos.Y = 0;
        }

    }
}

