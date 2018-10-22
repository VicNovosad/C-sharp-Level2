using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Organization : INotifyPropertyChanged
    {
        private bool flag;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Flag
        {
            get { return this.flag; }
            set
            {
                this.flag = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Flag)));
            }
        }

        public ObservableCollection<Department> DepartmentDb { get; set; }
        public ObservableCollection<Employee> EmployeeDb { get; set; }

        public Organization()
        {
            DepartmentDb = new ObservableCollection<Department>();

            EmployeeDb = new ObservableCollection<Employee>();

            DataInit();

            this.Flag = true;   
        }

        public void DataInit()
        {
            DepartmentDb.Add(new Department() { Name = "Accounting" });
            DepartmentDb.Add(new Department() { Name = "Human Resources" });
            DepartmentDb.Add(new Department() { Name = "Advertizing" });
            DepartmentDb.Add(new Department() { Name = "IT" });

            EmployeeDb.Add(new Employee() { Id = 1, Name = "Bob", LastName = "Dylan", Age = 22, Salary = 9000 });
            EmployeeDb.Add(new Employee() { Id = 2, Name = "John", LastName = "Surman", Age = 25, Salary = 6000 });
            EmployeeDb.Add(new Employee() { Id = 3, Name = "Jackson", LastName = "Michael", Age = 23, Salary = 8000 });
            EmployeeDb.Add(new Employee() { Id = 4, Name = "John", LastName = "Lennon", Age = 35, Salary = 2000 });
        }
    }

}
