using System;
using System.Drawing;
namespace MyGame
{
    /// <summary>
    /// Base Object (Point position(x,y), Point direction(x,y), Size size(x,y))
    /// </summary>
    class BaseObject
    {
        /// <summary>
        /// class properties
        /// </summary>
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public BaseObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        /// <summary>
        /// Virtual method "Draw"
        /// </summary>
        public virtual void Draw()
        {
            if (Program.FormNumber == 1)
                SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            else if (Program.FormNumber == 2)
                Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);

        }

        /// <summary>
        /// Virtual method "Update"
        /// </summary>
        public virtual void Update()
        {
            Position.X = Position.X - Direction.X;
            if (Position.X < 0) Position.X = Game.Width + Size.Width;
        }
    }
}