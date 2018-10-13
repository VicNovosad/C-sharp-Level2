using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Circle : BaseObject
    {

        // Base Object Constructor
        public Circle(Point position, Point direction, Size size, Game game) : base(position, direction, size, game)
        {
        }

        public Circle(Point pos, Point dir, Size size, int direction, Game game) : base(pos, dir, size, BaseObject.ChangeDirection(), game)
        {
            this.direction = RandomDirection(Size.Width);
        }

        /// <summary>
        /// Virtual method "Draw"
        /// </summary>
        public override void Draw(Game game)
        {
            game.Buffer.Graphics.DrawEllipse(pen, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}