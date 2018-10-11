using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class Star inherited from BaseObject
    /// </summary>
    class Star : BaseObject
    {
        /// <summary>
        /// Star object constructor
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="dir">Direction of the object (Speed and direction)</param>
        /// <param name="size">Size of the object</param>
        /// <param name="imageName"></param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Draw of the current object
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(pen, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X + Size.Width / 2, Pos.Y - Size.Width / 6, Pos.X + Size.Width / 2, Pos.Y + Size.Height + Size.Height / 5);
            Game.Buffer.Graphics.DrawLine(pen, Pos.X - Size.Width / 6, Pos.Y + Size.Height / 2, Pos.X + Size.Width + Size.Width / 6, Pos.Y + Size.Height / 2);

        }

    }


}
