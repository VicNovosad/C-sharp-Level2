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
    /// Employee Database
    /// </summary>
    class DBEmployee
    {
        internal List<Employee> DB;

        /// <summary>
        /// Constructor for loading the DataBase
        /// </summary>
        /// <param name="db">Employees Listing, Employee contains the fields: First Name, Last Name, Age, Gender, Position</param>
        public DBEmployee(List<Employee> db)
        {
            this.DB = db;
        }

        public DBEmployee() { }


        /// <summary>
        /// The method of creating a new database of employees based on the listing
        /// </summary>
        /// <param name="count">The number of employees</param>
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
        /// Conclusion of base of employees on the press in the text box
        /// </summary>
        /// <param name="txtbox">Text box for printing</param>
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
        ///Sorting of DataBase
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
