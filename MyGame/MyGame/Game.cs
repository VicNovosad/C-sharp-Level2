using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Random rnd = new Random();
        private static int objQty = 50;

        // Свойства - Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// constructor for static fields
        static Game()
        {
        }

        public static void Init(Form form)
        {
            Load();
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            //Width = form.Width;
            //Height = form.Height;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 300 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[objQty];

            for (int i = 0; i < _objs.Length / 4; i++)
            {
                int size = rnd.Next(1, 10);
                _objs[i] = new BaseObject(new Point(rnd.Next(1, 800), rnd.Next(1, 600)), new Point(rnd.Next(2, 10), rnd.Next(2, 15)), new Size(size, size));

            }

            for (int i = _objs.Length / 4; i < (_objs.Length / 4) * 2; i++)
            {
                int size = rnd.Next(1, 5);
                _objs[i] = new Star(new Point(rnd.Next(1, 800), rnd.Next(1, 600)), new Point(rnd.Next(2, 10), rnd.Next(2, 15)), new Size(size, size));
            }

            for (int i = (_objs.Length / 4) * 2; i < (_objs.Length / 4) * 3; i++)
            {
                int size = rnd.Next(1, 6);
                _objs[i] = new SpaceObjects(new Point(rnd.Next(1, 800), rnd.Next(1, 600)), new Point(rnd.Next(2, 10), rnd.Next(2, 15)), new Size(size, size), $"{rnd.Next(1, 10)}");
            }

            for (int i = (_objs.Length / 4) * 3; i < _objs.Length - 1; i++)
            {
                int size = rnd.Next(1, 6);
                _objs[i] = new SpaceObjects(new Point(rnd.Next(1, 800), rnd.Next(1, 600)), new Point(rnd.Next(2, 10), rnd.Next(2, 15)), new Size(size, size), $"{rnd.Next(11, 15)}");
            }

            _objs[_objs.Length - 1] = new SpaceShip(new Point(1, 215), new Point(1,1), new Size(1, 1), "SpaceShip2");

        }
    }
}