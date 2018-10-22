using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public Department Dep { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">String</param>
        /// <param name="age">integer</param>
        public Employee(string name, string lastName, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Employee()
        {
        }

        public override string ToString()
        {
            return $"{Id}\t{LastName}\t{Name}\t{Age}\t${Salary}\t";
            //{ Dep.Name}
        }
    }
}
