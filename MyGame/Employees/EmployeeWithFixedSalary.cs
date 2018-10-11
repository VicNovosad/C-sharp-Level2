using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// Class of employees with a fixed wage, derived from the class Employee
    /// </summary>
    class EmployeeWithFixedSalary : Employee
    {
        internal double salary;
        /// <summary>
        /// Constructor for class Fixed pay employee
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Last Name</param>
        /// <param name="sex">Gender</param>
        /// <param name="position">Position</param>
        /// <param name="age">Age (full years)</param>
        /// <param name="salary">Employee salary</param>
        public EmployeeWithFixedSalary(string name, string surname, string sex, string position, int age, double salary) : base(name, surname, sex, position, age)
        {
            this.salary = salary;
        }
        public EmployeeWithFixedSalary() { }

        /// <summary>
        /// Calculation of the average monthly salary
        /// </summary>
        /// <returns></returns>
        protected override double AvarageMounthSalary()
        {
            return salary;
        }



    }
}