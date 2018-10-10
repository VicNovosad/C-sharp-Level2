using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    /// <summary>
    /// Базовый класс сотрудника
    /// </summary>
    abstract class Employee : IComparable
    {
        internal string name;
        internal string surname;
        internal string sex;
        internal string position;
        internal int age;

        #region Properties
        //public string Name { get { return name; } set { name = value; } }
        //public string Surname { get { return surname; } set { surname = value; } }
        //public string Sex { get { return sex; } set { sex = value; } }
        //public string Position { get { return position; } set { position = value; } }
        //public int Age { get { return age; } set { age = value; } }

        #endregion
        /// <summary>
        /// Сотрудник, конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="sex">Пол</param>
        /// <param name="position">Должность</param>
        /// <param name="age">Возраст (полных лет)</param>

        public Employee(string name, string surname, string sex, string position, int age)
        {
            this.name = name;
            this.surname = surname;
            this.sex = sex;
            this.position = position;
            this.age = age;

        }

        public Employee() : this("Ivan", "Ivanov", "male", "CEO", 20) { }

        protected abstract double AvarageMounthSalary();

        public int CompareTo(Object obj)
        {
            return (obj as Employee).age > this.age ? -1 : 1;
        }

    }
}
