﻿using System;
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
        protected Point StartPos { get; set; }
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Pen pen;

        protected static Random rnd = new Random();

        private int direction;

        /// <summary>
        /// Base Object Constructor
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public BaseObject(Point position, Point direction, Size size) : this(position, direction, size, ChangeDirection())
        {
            this.direction = RandomDirection(Size.Width);
        }

        /// <summary>
        /// Base Object Constructor with direction
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        public BaseObject(Point pos, Point dir, Size size, int direction)
        {
            Pos = pos;
            StartPos = pos;
            Dir = dir;
            Size = size;
            pen = RandomColor(size.Width);
            this.direction = direction;
        }


        /// <summary>
        /// Virtual method "Draw"
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(pen, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Virtual method "Update"
        /// </summary>
        public virtual void Update()
        {
            if (Program.GameStart == true)
            {
                Pos.X = Pos.X - Dir.X;
                if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            }
            else
            {
                SPObjBehavior();
            }
        }

        /// <summary>
        /// Splash Screen Objects behaviour
        /// </summary>
        private void SPObjBehavior()
        {
            switch (this.direction)
            {
                case 1:                     //Left-Up
                    Pos.X = Pos.X - Dir.X;
                    Pos.Y = Pos.Y - Dir.Y;
                    break;
                case 2:                     //Left-Down
                    Pos.X = Pos.X - Dir.X;
                    Pos.Y = Pos.Y + Dir.Y;
                    break;
                case 3:                     //Right-Up
                    Pos.X = Pos.X + Dir.X;
                    Pos.Y = Pos.Y - Dir.Y;
                    break;
                default:                    //Right-Down
                    Pos.X = Pos.X + Dir.X;
                    Pos.Y = Pos.Y + Dir.Y;
                    break;
            }

            if (Pos.X < 0 || Pos.Y < 0 || (Pos.X > Game.Width) || (Pos.Y > Game.Height))
            {
                Pos.X = StartPos.X;
                Pos.Y = StartPos.Y;
                direction = ChangeDirection();
                this.pen = RandomColor(Size.Width);
            }
        }

        private static int ChangeDirection()
        {
            return rnd.Next(1, 10);
        }

        /// <summary>
        /// Return random direction depends of the size of the object
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static int RandomDirection(int size)
        {
            switch (size) 
            {
                case 1:
                    return 1;
                case 2:
                    return rnd.Next(1,2);
                case 3:
                    return rnd.Next(1,3);
                case 4:
                    return rnd.Next(1,4);
                default:
                    return rnd.Next(1,5);
            }
        }

        /// <summary>
        /// Return random color depends of received size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static Pen RandomColor(int size)
            {
                int rndCol;
                if (size > 2) rndCol = rnd.Next(3, 7);
                else rndCol = rnd.Next(0, 7);
                switch (rndCol)
                {
                    case 0:
                        return Pens.Blue;
                    case 1:
                        return Pens.Red;
                    case 2:
                        return Pens.Green;
                    case 3:
                        return Pens.Cyan;
                    case 4:
                        return Pens.LightSteelBlue;
                    case 5:
                        return Pens.Yellow;
                    case 6:
                        return Pens.LightBlue;
                    default:
                        return Pens.LightGray;
                }
            }

    }
}