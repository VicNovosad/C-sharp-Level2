using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// Класс сотрудников с почасовой оплатой труда, производный от класса Employee
    /// </summary>
    class EmployeePerHourSalary : Employee
    {
        internal double salaryPerHour;

        //public double SalaryPerHour { get { return salaryPerHour; }set { salaryPerHour = value; } }
        /// <summary>
        /// Сотрудник с почасовой оплатой, конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="sex">Пол</param>
        /// <param name="position">Должность</param>
        /// <param name="age">Возраст (полных лет)</param>
        /// <param name="salary">Зарплата сотрудника в час</param>
        public EmployeePerHourSalary(string name, string surname, string sex, string position, int age, double salaryPerHour) :
            base(name, surname, sex, position, age)
        {
            this.salaryPerHour = salaryPerHour;
        }

        public EmployeePerHourSalary() { }

        /// <summary>
        /// Расчет среднемесячной зарплаты
        /// </summary>
        /// <returns></returns>
        protected override double AvarageMounthSalary()
        {
            double avarageSalary = salaryPerHour * 20.8 * 8;
            return avarageSalary;
        }
    }
}
