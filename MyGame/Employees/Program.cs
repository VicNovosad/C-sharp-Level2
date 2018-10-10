using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Employees
{
    static class Program
    {
        public static TextBox txtbx;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 1000;
            form.Height = 600;
            txtbx = new TextBox();
            txtbx.Width = 1000;
            txtbx.Height = 600;
            txtbx.Font = new Font("Courier New", (float)12);
            txtbx.BackColor = Color.WhiteSmoke;
            txtbx.Multiline = true;
            form.Controls.Add(txtbx);

            form.Show();
            DBEmployee db = new DBEmployee();
            db.CreateDB(15);
            db.DBSort();
            db.PrintDB(txtbx);
            Application.Run(form);


        }
    }
}
