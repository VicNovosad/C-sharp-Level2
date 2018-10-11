using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// A class of hourly wage employees derived from the Employee class
    /// </summary>
    class EmployeePerHourSalary : Employee
    {
        internal double salaryPerHour;

        //public double SalaryPerHour { get { return salaryPerHour; }set { salaryPerHour = value; } }
        /// <summary>
        /// Constructor for Employee with hourly pay class
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">LastName</param>
        /// <param name="sex">Gender</param>
        /// <param name="position">Position</param>
        /// <param name="age">Age (full years)</param>
        /// <param name="salary">Employee salary per hour</param>
        public EmployeePerHourSalary(string name, string surname, string sex, string position, int age, double salaryPerHour) :
            base(name, surname, sex, position, age)
        {
            this.salaryPerHour = salaryPerHour;
        }

        public EmployeePerHourSalary() { }

        /// <summary>
        /// Calculation of the average monthly salary
        /// </summary>
        /// <returns></returns>
        protected override double AvarageMounthSalary()
        {
            double avarageSalary = salaryPerHour * 20.8 * 8;
            return avarageSalary;
        }
    }
}
