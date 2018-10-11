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
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {        
        }
        public override void Draw()
        {
            TakenPlace = new RectangleF(Pos, Size);
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawImage(Img, TakenPlace);
        }
        public override void Update()
        {
            CheckPosition();

            if (Pos.X < Game.Width)
                Pos.X = Pos.X + 20;
            else
                Pos.X = 0;
        }

        private void CheckPosition()
        {
            for (var i = 0; i < Game.Asteroids.Count; i++)
            {
                if (TakenPlace.IntersectsWith(Game.Asteroids[i].TakenPlace))
                {
                    Pos.X = 0;
                    Pos.Y = 300;
                    Game.Asteroids[i].Pos.X = Game.Width;
                    Game.Asteroids[i].Pos.Y = 500;
                    break;
                }
            }
        }

    }
}
