using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lesson5
{
    /// <summary>
    /// Interaction logic for WinEmployeeEdit.xaml
    /// </summary>
    public partial class WinEmployeeEdit : Window
    {
        public WinEmployeeEdit(Employee e) : this (e, Visibility.Collapsed)
        {
        }

        public WinEmployeeEdit(Employee e, Visibility btnVisability)
        {
            InitializeComponent();
            mainStackPanel.DataContext = e;
            btnAddEmployee.Visibility = btnVisability;
        }
    }
}
