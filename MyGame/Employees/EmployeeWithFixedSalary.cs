using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// Класс сотрудников с фиксированной оплатой труда, производный от класса Employee
    /// </summary>
    class EmployeeWithFixedSalary : Employee
    {
        internal double salary;
        /// <summary>
        /// Сотрудник с фиксированной оплатой, конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="sex">Пол</param>
        /// <param name="position">Должность</param>
        /// <param name="age">Возраст (полных лет)</param>
        /// <param name="salary">Зарплата сотрудника</param>
        public EmployeeWithFixedSalary(string name, string surname, string sex, string position, int age, double salary) : base(name, surname, sex, position, age)
        {
            this.salary = salary;
        }
        public EmployeeWithFixedSalary() { }

        /// <summary>
        /// Расчет среднемесячной зарплаты
        /// </summary>
        /// <returns></returns>
        protected override double AvarageMounthSalary()
        {
            return salary;
        }



    }
}