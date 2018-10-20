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
        //ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        //ObservableCollection<Department> departments = new ObservableCollection<Department>();

        Random r = new Random();

        Organization org;

        public MainWindow()
        {
            InitializeComponent();

            org = new Organization();

            mainGrid.DataContext = org;
        }

        private void edtDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (tbDepartment.Text != "")
                org.DepartmentDb[cbDepartments.SelectedIndex].Name = $"{tbDepartment.Text}" ;
            else 
                org.DepartmentDb[cbDepartments.SelectedIndex].Name += "1" ;
            this.Title = $"{org.DepartmentDb[cbDepartments.SelectedIndex].Name}";
        }

        /// <summary>
        /// Обработка контролов
        /// </summary>
        //private void Controls()
        //{
        //    lvDepartments.SelectionChanged += lvDepartments_SelectionChanged;
        //    btnChangeDepartment.Click += btnChangeDepartment_Click;
        //    lvEmployees.SelectionChanged += lvEmployees_SelectionChanged;
        //    btnAdd.Click += btnAdd_Click;
        //}

        private void lvEmployee_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        private void lvEmployee_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MessageBox.Show(e.AddedItems[0].ToString());
        }

        //        private void Button_Click(object sender, RoutedEventArgs e)
        //        {
        //        }

        //        /// <summary>
        //        /// Окно для добавления сотрудников и отделов
        //        /// </summary>
        //        AddWindow window;
        //        /// <summary>
        //        /// Вызов формы с добавлением сотрудников и отделов
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
        //        private void btnAdd_Click(object sender, RoutedEventArgs e)
        //        {
        //            window = new AddWindow();
        //            window.Owner = this;
        //            window.Show();
        //        }
        //        /// <summary>
        //        /// Смена отдела у сотрудника
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
        //        private void btnChangeDepartment_Click(object sender, RoutedEventArgs e)
        //        {
        //            //if (lvDepartments.SelectedItem != null)
        //            //    (lvDepartments.SelectedItem as Department).AddEmployee((lvDepartments.SelectedItem as Department).EmpChangeDep(lvEmployees.SelectedItem as Employee));
        //        }
        //        /// <summary>
        //        /// Добавляет список отделов в комбобокс для смены отдела(по выбору сотрудника)
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
        //        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //        {
        //            lvDepartments.ItemsSource = departments;
        //        }
        //        /// <summary>
        //        /// Событие, добавляющее в правый листбокс список сотрудников в данном отделе(срабатывает по выбору отдела в левой форме)
        //        /// </summary>
        //        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //        {
        //            //lvEmployees.ItemsSource = (lvDepartments.SelectedItem as Department).Employees;
        //        }
        //        /// <summary>
        //        /// Изначальный список отделов и сотрудников, задание
        //        /// 1) Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
        //        /// </summary>
        //        /// <param name="sender"></param>
        //        /// <param name="e"></param>
        //        private void Init_Click(object sender, RoutedEventArgs e)
        //        {
        //            if (lvDepartments.ItemsSource == null)
        //            {
        //                lvDepartments.ItemsSource = departments;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //            departments.Add(new Department("IT"));
        //            int numOfDepartments = 10;
        //            for (int i = 0; i < numOfDepartments; i++)
        //            {
        //                departments.Add(new Department($"Department_{i}"));
        //            }
        //            int numOfStartEmployees = 10;
        //            foreach (Department department in departments)
        //            {
        //                ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        //                for (int i = 0; i < numOfStartEmployees; i++)
        //                {
        //                    employees.Add(new Employee(
        //                        $"Name_{i}",
        //                        $"LastName_{i}_{department.Name}ов",
        //                        (i + 1) * 10000));
        //                }
        //                //department.AddEmployees(employees);
        //            }
        //        }

    }
}






//list.ItemsSource = col;

//btnAdd.Click += delegate
//{
//    for (int i = 0; i < 50; i++)
//    {
//        col.Add(r.Next(100, 1600));
//    }
//};

//btnSort.Click += delegate
//{
//    Sort();
//};

//private async void Sort()
//        {
//            for (int i = 0; i < col.Count - 1; i++)
//            {
//                int index = i;
//                for (int j = i; j < col.Count; j++)
//                {
//                    if (col[j] > col[index]) index = j;
//                }
//                await Task.Delay(100);
//                int t = col[i];
//                col[i] = col[index];
//                col[index] = t;
//            }
//        }
