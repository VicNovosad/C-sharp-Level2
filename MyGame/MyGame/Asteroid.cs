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
        public string ImageName { get; set; }

        public Asteroid(Size size) : this(size, 1)
        {
        }

        public Asteroid(Size size, int power) : base(new Point(100,100), new Point(-5, 0), size)
        {
            Power = power;
            RandomPos();
            switch (power)
            {
                case 1:
                    ImageName = "Asteroid0";
                    Power = -1;
                    break;
                case 2:
                    ImageName = "Asteroid1";
                    Power = 2;
                    break;
                default:
                    ImageName = "Asteroid2";
                    Power = 1;
                    break;
            }
            ImgFromFile(ImageName);
        }

        public Asteroid(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            Power = 1;
            ImageName = imageName;
            ImgFromFile(ImageName);
        }

        public override void Draw()
        {
            TakenPlace = new RectangleF(Pos, Size);
            if (Img.Height > 0 || Img.Height > 0)
                Game.Buffer.Graphics.DrawImage(Img, TakenPlace);
            else
                Game.Buffer.Graphics.FillEllipse(Brushes.White, TakenPlace);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width)
                RandomPos();
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y < -Size.Width)
                RandomPos();
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            //if (Pos.X > Game.Width) Pos.X = Game.Width - Size.Width;
            //if (Pos.Y < 0) Pos.Y = Game.Height;
            //if (Pos.Y > Game.Height) Pos.Y = 0;
        }
        public void RandomPos()
        {
            Pos.X = rnd.Next(Game.Width + 30, Game.Width + 50);
            Pos.Y = rnd.Next(125, Game.Height - 125);
            Dir.X = -(rnd.Next(5, 50) / 5);
            Dir.Y = rnd.Next(-1, 1);
        }
    }
}

