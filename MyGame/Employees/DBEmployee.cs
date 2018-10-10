using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Employees
{
    /// <summary>
    /// База данных сотрудников
    /// </summary>
    class DBEmployee
    {
        internal List<Employee> DB;

        /// <summary>
        /// Конструктор для загрузки базы
        /// </summary>
        /// <param name="db">Листинг сотрудников, Сотрудник содержит поля: Имя, Фамилия, Возраст, Пол, Должность</param>
        public DBEmployee(List<Employee> db)
        {
            this.DB = db;
        }

        public DBEmployee() { }


        /// <summary>
        /// Метод создания новой базы слотрудников на основе листинга
        /// </summary>
        /// <param name="count">Количество сотрудников</param>
        public void CreateDB(int count)
        {
            DB = new List<Employee>();
            Random rnd = new Random();
            int num;

            for (int i = 0; i < count; i++)
            {

                num = rnd.Next(0, 2);
                if (num == 0)
                {
                    EmployeePerHourSalary person = new EmployeePerHourSalary();
                    person.salaryPerHour = 500 * i;
                    DB.Add(person);
                }
                if (num == 1)
                {
                    EmployeeWithFixedSalary person = new EmployeeWithFixedSalary();
                    person.salary = 10000 * num;
                    DB.Add(person);
                }

                DB[i].name = "Alex";
                DB[i].surname = "Phillips";

                Enum sexFromEnum = (Sex)num;
                DB[i].sex = sexFromEnum.ToString();

                DB[i].age = rnd.Next(25, 50);

                Enum pos = (Positions)rnd.Next(0, 6);
                DB[i].position = pos.ToString();
            }
        }

        /// <summary>
        /// Вывод базы сотрудников на печать в текст бокс
        /// </summary>
        /// <param name="txtbox">Текст бокс для вывода на печать</param>
        public void PrintDB(TextBox txtbox)
        {
            foreach (var emp in DB)
            {
                if (emp is EmployeePerHourSalary)
                {
                    EmployeePerHourSalary emphour = emp as EmployeePerHourSalary;
                    string mesg = System.String.Format("Name: {0}, Surname: {1}, Sex: {2}, Posiotion: {3}, Age: {4}, Salary per hour: {5}", emphour.name, emphour.surname, emphour.sex, emphour.position, emphour.age, emphour.salaryPerHour);
                    txtbox.Text = txtbox.Text + '\r' + '\n' + mesg;
                }
                if (emp is EmployeeWithFixedSalary)
                {
                    EmployeeWithFixedSalary empfixed = emp as EmployeeWithFixedSalary;
                    string mesg = System.String.Format("Name: {0}, Surname: {1}, Sex: {2}, Posiotion: {3}, Age: {4}, Salary: {5}", empfixed.name, empfixed.surname, empfixed.sex, empfixed.position, empfixed.age, empfixed.salary);
                    txtbox.Text = txtbox.Text + '\r' + '\n' + mesg;
                }
            }
        }

        /// <summary>
        ///Сортировка базы 
        /// </summary>
        public void DBSort()
        {
            DB.Sort();
        }

        public enum Positions
        {
            CEO,
            CFO,
            Accountant,
            Administrator,
            Assistant,
            Auditor,
            Programmer
        }
        public enum Sex
        {
            Male,
            Female
        }
    }
}
