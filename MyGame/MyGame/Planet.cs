using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Class planet inherited from SpaceObjects
    /// </summary>
    class Planet : SpaceObjects
    {
        private string imageName;

        /// <summary>
        /// Planet object constructor
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="dir">Direction of the object (Speed and direction)</param>
        /// <param name="size">Size of the object</param>
        /// <param name="imageName"></param>
        public Planet(Point pos, Point dir, Size size, string imageName, Game game) : base(pos, dir, size, imageName, game)
        {
            this.imageName = imageName;
        }

    }
}