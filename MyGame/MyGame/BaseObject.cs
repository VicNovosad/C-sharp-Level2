using System;
using System.Drawing;
namespace MyGame
{
    class BaseObject
    {
        protected Point Pos;  //position
        protected Point Dir; //direction
        protected Size Size;
        protected int SizeDir;
        private static Random rnd = new Random();

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            SizeDir = rnd.Next(1, 2);
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Resize()
        {

            //Console.WriteLine("Was " + this.Size.Height);
            if (this.Size.Height < 2)
            {
                this.Size.Height += 1;
                this.Size.Width += 1;
            }
            else if (this.Size.Height > 15)
            {
                this.Size.Height -= 1;
                this.Size.Width -= 1;
            }
            else if (SizeDir == 1)
            {
                this.Size.Height -= 1;
                this.Size.Width -= 1;
            }
            else if (SizeDir == 2)
            {
                this.Size.Height += 1;
                this.Size.Width += 1;
            }


            //Console.WriteLine("Now " + this.Size.Height);
            //Console.ReadKey();
        }

        public virtual void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            //Pos.X = Pos.X + Dir.X;
            //Pos.Y = Pos.Y + Dir.Y;
            //if (Pos.X <= 0) Dir.X = -Dir.X;
            //if (Pos.X >= Game.Width - Size.Width - 1) Dir.X = -Dir.X;
            //if (Pos.Y <= 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height - Size.Width - 1) Dir.Y = -Dir.Y;
            //Resize();       
        }
    }
}