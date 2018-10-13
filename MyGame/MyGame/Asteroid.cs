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
        public Asteroid(Point pos, Point dir, Size size, Game game) : base(pos, dir, size, game)
        {
            Power = 1;
        }

        public Asteroid(Point pos, Point dir, Size size, string imageName, Game game) : base(pos, dir, size, game)
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

        public override void Draw(Game game)
        {
            TakenPlace = new RectangleF(Pos, Size);
            if (Img.Height > 0 || Img.Height > 0)
                game.Buffer.Graphics.DrawImage(Img, TakenPlace);
            else
                game.Buffer.Graphics.FillEllipse(Brushes.White, TakenPlace);
        }
        public override void Update(Game game)
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -100) Pos.X = game.Width + Size.Width;
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            //if (Pos.X > Game.Width) Pos.X = Game.Width - Size.Width;
            //if (Pos.Y < 0) Pos.Y = Game.Height;
            //if (Pos.Y > Game.Height) Pos.Y = 0;
        }
    }
}

