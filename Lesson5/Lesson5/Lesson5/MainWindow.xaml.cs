using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Organization org;

        public MainWindow()
        {
            InitializeComponent();

            org = new Organization();

            mainGrid.DataContext = org;
            //lvEmployees.ItemsSource = org.EmployeeDb;
            //lvDepartments.ItemsSource = org.DepartmentDb;
        }

        /// <summary>
        /// Handling controls
        /// </summary>

        //private void lvDepartments_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    new WinDepEdt(lvDepartments.SelectedItem as Department).ShowDialog();
        //    //WinDepartmentEdit.btnAddDep.IsEnabled = "False";
        //}

        private void lvEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WinEmployeeEdit wee = new WinEmployeeEdit(lvEmployees.SelectedItem as Employee);
            wee.ShowDialog();
            wee.btnAddEmployee.IsEnabled = false;
        }

        private void edtDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (tbDepartment.Text != "")
                org.DepartmentDb[cbDepartments.SelectedIndex].Name = $"{tbDepartment.Text}" ;
            else 
                org.DepartmentDb[cbDepartments.SelectedIndex].Name += "*" ;
            this.Title = $"{org.DepartmentDb[cbDepartments.SelectedIndex].Name}";
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            WinEmployeeEdit wee = new WinEmployeeEdit(new Employee(), Visibility.Visible);
            wee.Height = 210;
            wee.ShowDialog();
            wee.btnAddEmployee.IsEnabled = false;
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            WinDepEdt wde = new WinDepEdt(new Department(), Visibility.Visible);
            wde.Height = 125;
            wde.ShowDialog();
            wde.btnAddDep.IsEnabled = false;
        }
    }
}
