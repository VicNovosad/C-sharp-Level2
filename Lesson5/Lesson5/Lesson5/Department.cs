using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Department : INotifyPropertyChanged
    {
        public int CurrentId { get; set; } = 0;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {   get => this.name;
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public static ObservableCollection<string> Dep { get; set; } = new ObservableCollection<string>() { "" };
        public static int DepQty { get; set; } = 0;

        //public static ObservableCollection<int> DepId { get; set; } = new ObservableCollection<int>() { 0 };
        //private string currentDep = "";


        //public string Name
        //{
        //    get
        //    {
        //        return currentDep;
        //    }
        //    protected set
        //    {
        //        currentDep = value;
        //    }
        //}


        //{ get; set; } = "";

        //{
        //    get => currentDep;
        //    set => currentDep = value;
        //        //Add(value);
        //}


        //{ "Accounting", "Human Resources", "Advertizing"};
        //public static List<int> DepId { get; set; } = new List<int> {1,2,3};

        //public int CurrentDep { get; set } = 0;

        public Department(/*string nameOfDepartment*/)
        {
            //Add(nameOfDepartment);
            //currentDep = nameOfDepartment;
        }

        public Department(string name)
        {
            Add(name);
            //currentDep = nameOfDepartment;
        }

        public void Add(string department)
        {
            bool newItem = true;
            for (int i = 0; i < Dep.Count() - 1; i++)
            {
                if (department == Dep[i])
                {
                    newItem = false;
                    CurrentId = i;
                }
            }
            if (newItem)
            {
                Dep.Add(department);
                CurrentId = Dep.Count();
            }
        }



        public override string ToString()
        {
            return this.Name;
        }

    }
}
