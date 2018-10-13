﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    class SpaceObjects : BaseObject
    {
        private string imageName;

        /// <summary>
        /// Space Objects constructor
        /// </summary>
        /// <param name="pos">Position of the object</param>
        /// <param name="dir">Direction of the object (Speed and direction)</param>
        /// <param name="size">Size of the object</param>
        /// <param name="imageName"></param>
        public SpaceObjects(Point pos, Point dir, Size size, string imageName) : base(pos, dir, size)
        {
            this.imageName = imageName;
            try
            {
                // Creating an image
                Img = Image.FromFile($"..\\..\\{imageName}.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Draw of the current object
        /// </summary>
        public override void Draw()
        {
            Size.Height = Img.Height;
            Size.Width = Img.Width;
            TakenPlace = new RectangleF(Pos, Size);
            // Draw image to screen
            Game.Buffer.Graphics.DrawImage(Img, TakenPlace);

        }

        /// <summary>
        /// Update of the current object
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -100) Pos.X = Game.Width + Size.Width;
        }

    }
}