using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bullet : BaseObject
    {
        private int stage = 0;
        private const int imgQty = 3; // Quantity of sprites
        private Image[] ImgArr { get; set; } = new Image[imgQty];

        public Bullet(Point pos, Point dir, Size size, string imageName, Game game) : base(pos, dir, size, game)
        {
            StartPos = Pos;
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

        public override void Draw(Game game)
        {
            TakenPlace = new RectangleF(Pos, Size);
            game.Buffer.Graphics.DrawImage(ImgArr[stage], TakenPlace);
            //if (Img.Height > 0 || Img.Height > 0)
            //else
            //    game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update(Game game)
        {
            if (stage < imgQty - 1) stage++;
            else stage = 0;

            CheckPosition(game);

            if (Pos.X < game.Width)
                Pos.X = Pos.X + 20;
            else
                Pos = StartPos;
        }

        private void CheckPosition(Game game)
        {
            for (var i = 0; i < game.Asteroids.Count; i++)
            {
                if (TakenPlace.IntersectsWith(game.Asteroids[i].TakenPlace))
                {
                    Pos = StartPos;
                    game.Asteroids[i].Pos.X = rnd.Next(200, game.Width);
                    game.Asteroids[i].Pos.Y = 0;
                    break;
                }
            }
        }

    }
}
