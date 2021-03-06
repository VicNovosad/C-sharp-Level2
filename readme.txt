﻿Lesson2

Посмотреть в начале о том как здавать через Git

27:00 - 29:00 посмотреть как это называется


***********************
Lesson1

3 способа использования this:
1. this.x = 1;
2. Индексаторы - позволяют индексировать объекты и обращаться к данным по индексу. Фактически с помощью индексаторов мы можем работать с объектами как с массивами. По форме они напоминают свойства со стандартными блоками get и set, которые возвращают и присваивают значение.
	// создаем индексируемое свойство
    public int this [ int i]
    {
    get { return a [ i ]; }
    set { a [ i ] = value ; }
    }
3. Переопределение конструктор

--
? статический конструктор : Они
выполняются при самом первом создании объекта данного класса или первом обращении к его
статическим членам (если таковые имеются).
--
? инкапсуляция 
Инкапсуляция - представляет одну из ключевых концепций объектно-ориентированного программирования. Применение модификаторов доступа типа private защищает переменную от внешнего доступа. Для управления доступом во многих языках программирования используются специальные методы, геттеры и сеттеры. В C# их роль, как правило, выполняют свойства.

1) Свойства (геттер и сеттер)
 class Account
{
    private int sum;
    public int Sum
    {
        get {return sum;}
        set
        {
            if (value > 0)
            {
                sum=value;
            }
        }
    }
}
2) Автоматические свойства
Свойства управляют доступом к полям класса. Однако что, если у нас с десяток и более полей, то определять каждое поле и писать для него однотипное свойство было бы утомительно. Поэтому в фреймворк .NET были добавлены автоматические свойства. Они имеют сокращенное объявление:
class Person
{
    public string Name { get; set; } 
    public int Age { get; set; }
         
    public Person(string name, int age) // Конструктор(метод инициализации объекта класса) (называется так же как и класс)
    {
        Name = name; //переменная name создается автоматическим свойством Name вместе с геттером и сеттером; сеттер принимает передаваемое значение value при вызове этого свойства из вне класса)
        Age = age;
    }
}

// Свойство X для доступа к полю x
public double X
{
get => x;
set => x = value ;
}
// Доступ к полям из вне класса стал более логичным при записи
v1.X = 10 ;
v2.X = -10 ;

3) Автосвойствам можно присвоить значения по умолчанию (инициализация автосвойств):
    public string Name { get; set; } = "Tom";
    public int Age { get; set; } = 23;

4) Автосвойства также могут иметь модификаторы доступа:
class Person
{
    public string Name { private set; get;}
    public Person(string n)
    {
        Name = n;
    }
}
// Использование автосвойства из вне класса:
Person tom = new Person { Name = "Tom" };



5) Сокращенная запись свойств
Как и методы, мы можем сокращать свойства. Например:
class Person
{
    private string name;
     
    // эквивалентно public string Name { get { return name; } }
    public string Name => name;
}

    public void SetX ( double value ) => x = value ;

// Метод для получения данных в строковой форме
public string ToString () => $"X= {x} Y= {y} " ;

static void Main ( string [] args)
{
 Console.WriteLine( $"v1: {v1.ToString()} " );
}
--
? Перегрузка операторов позволяет использовать пользовательские классы с привычными операторами +, -, *, = и другими.
public static Vector operator +(Vector v1, Vector v2)
{
   Vector res = new Vector
   {
   X = v1.X + v2.X,
   Y = v1.Y + v2.Y
   };
   return res;
}
--
? implicit - Ключевое слово implicit служит для объявления неявного оператора преобразования пользовательского типа. Этот оператор обеспечивает неявное
преобразование между пользовательским типом и другим типом, если при преобразовании исключается утрата данных 
//explicit - значит, мы указываем на потерю данных
public static explicit operator Vector ( double x) => new Vector(x,x);
public static implicit operator double (Vector x) => x.X;
--
Значение null и Nullable-типы
Бывают случаи, когда программистам удобно, чтобы объекты значимых типов данных имели
значение null, то есть были бы не определены. Для этого надо использовать знак вопроса ( ?) после
типа значений.
int ? test = null ;
bool ? isEnabled = null ;

Оператор ?? называется оператором null-объединения. Он применяется для установки значений по
умолчанию для типов значений и ссылочных типов, которые допускают значение null. Оператор ??
возвращает левый операнд, если он не равен null – иначе возвращается правый операнд (в этом
случае левый операнд должен принимать null):
int ? x = null ;
int y = x ?? 2 ; // Равно 2, так как x равен null
int ? a = 5 ;
int b = a ?? 10 ; // Равно 5, так как a не равен null

--
? Наследование
Наследование представляет собой процесс, в ходе которого один объект приобретает свойства
другого.
В языке С# наследуемый класс называется базовым, а наследующий – производным. Следовательно,
производный класс представляет собой специализированный вариант базового класса. Он наследует
все переменные, методы, свойства и индексаторы, определяемые в базовом классе, добавляя к ним
собственные элементы.
Наследование является одним из трех основополагающих принципов объектно-ориентированного
программирования, поскольку оно допускает создание иерархических классификаций. Благодаря
наследованию можно создать общий класс, в котором определяются характерные особенности,
присущие множеству связанных элементов. От этого класса могут затем наследовать другие, более
конкретные классы, добавляя в него свои индивидуальные особенности.

//Конструкторы не передаются производному классу при наследовании. И если в базовом классе не
определен конструктор по умолчанию без параметров (а только конструкторы с параметрами), то в
производном классе мы обязательно должны вызвать один из этих конструкторов через ключевое
слово base .

public class Animals
{
	private string _name;
	private int _numberPaws;
	public Animals ( string name, int numberPaws)
	{
		_name = name;
		_numberPaws = numberPaws;
	}
}
public sealed class Cat : Animals
{
	private ushort ? _lengthTail;
	public Cat ( string name, int numberPaws, ushort ? lengthTail) : base (name,
		numberPaws)
	{
		_lengthTail = lengthTail;
	}
}

---
"?" Значение null и Nullable-типы
Бывают случаи, когда программистам удобно, чтобы объекты значимых типов данных имели
значение null, то есть были бы не определены. Для этого надо использовать знак вопроса ( ?) после
типа значений
int ? test = null ;
bool ? isEnabled = null ;

Оператор ?? называется оператором null-объединения. Он применяется для установки значений по
умолчанию для типов значений и ссылочных типов, которые допускают значение null. Оператор ??
возвращает левый операнд, если он не равен null – иначе возвращается правый операнд (в этом
случае левый операнд должен принимать null): 
int ? x = null ;
int y = x ?? 2 ; // Равно 2, так как x равен null
int ? a = 5 ;
int b = a ?? 10 ; // Равно 5, так как a не равен null

?. invoke оператор (элвис оператор)
С версии C# 6.0 в языке появился оператор условного null ( Null-Conditional Operator), или
элвис-оператор. Он позволяет упростить проверку на значение null в условных конструкциях:
class Person
{
    public Adress Adress;
}

class Adress
{
    public string City;
}

class Program
{
    private string GetCityInPast (Person person)
    {
        // До C# 6.0
        string city = String.Empty;
        if (person != null )
        {
            if (person.Adress != null )
            {
                city = person.Adress.City;
            }
        }
        return city;
    }
    private string GetCityInPresent (Person person)
    {
        return person?.Adress?.City ?? "" ; // Начиная с C# 6.0
    }
}
***********************