namespace Task;

// person class ...........
public class Person
{
    private string _name;
    private int _age;



    public string Name
    {
        get { return _name; }
        set
        {
            if (value == null && value == "" && value.Length > 32)
            {
                throw new Exception("invalid input");
            }

            _name = value;
        }
    }


    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0 || value > 128)
            {
                throw new Exception("invalid age input");
            }

            _age = value;
        }
    }





    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // abstract method
    public virtual void print()
    {
        Console.WriteLine($"my name is {Name} ,and my age is {Age}");
    }

}



//class student  .................

public class Student : Person
{


    private int _year;
    private float _gpa;

    public int year
    {
        get { return _year; }
        set
        {
            if (value < 1 || value > 5)
            {
                throw new Exception("Invalid input for year");
            }
            _year = value;
        }
    }

    public float Gpa
    {
        get { return _gpa; }
        set
        {
            if (value < 0 || value > 4)
            {
                throw new Exception("Invalid input for Gpa");
            }
            _gpa = value;
        }
    }

    public Student(string name, int age, int year, float gba) : base(name, age)
    {
        this.year = year;
        this.Gpa = gba;
    }

    public override void print()
    {
        Console.WriteLine($"my name is {Name} ,my age is {Age} ,my gba is {Gpa}");
    }
}



// class staff .........

public class Staff : Person
{

    private double _salary;
    public double Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0 || value > 120000)
            {
                throw new Exception("Invalid input Salary");
            }
            _salary = value;
        }
    }
    private int _joinyear;
    public int Joinyear
    {
        get { return _joinyear; }
        set
        {
            var age = value - (2022 - Age);
            if (age <= 21)
            {

                throw new Exception("Invalid input Joinyear");
            }
            _joinyear = value;
        }
    }
    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        Salary = salary;
        Joinyear = joinyear;
    }

    public override void print()
    {
        Console.WriteLine($"my name is {Name}, my age is {Age}, and my salary is {Salary}");
    }
}





// database class  .......................

public class Database
{
    public Person[] people = new Person[50];
    

    private int _items = 0;

    // add student
    public void AddStudent(Student student)
    {
        if (_items == 50) return;
        people[_items++] = student;
    }

    // add staff
    public void AddStaff(Staff staff)
    {
        if (_items == 50) return;
        people[_items++] = staff;

    }

    // add person
    public void AddPerson(Person person)
    {
        if (_items == 50) return;
        people[_items++] = person;

    }




    // print all
    public void printAll()
    {
        foreach (var pers in people)
        {
            pers?.print();
        }
    }


}





// execution  ....................................

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        var database = new Database();
        //Console.Write("Name: ");
        //var name = Console.ReadLine();
        //Console.Write("Age: ");
        //var age = Convert.ToInt32(Console.ReadLine());
        //Console.Write("year: ");
        //var year = Convert.ToInt32(Console.ReadLine());
        //Console.Write("Gba: ");
        //var gba = Convert.ToSingle( Console.ReadLine());

        //var student = new Student(name, age, year, gba);


        


        while (true)
        {
            Console.WriteLine("1) student 2)staff 3) Person 4)printAll");
            Console.WriteLine("Option: ");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gba: ");
                    var gba = Convert.ToSingle(Console.ReadLine());

                    try
                    {
                        var student = new Student(name, age, year, gba);
                        database.AddStudent(student);

                    }
                    catch(Exception excep)
                    {
                        Console.WriteLine(excep.Message);
                    }
                    break;
                case 2:

                    Console.Write("Name: ");
                    var nam = Console.ReadLine();
                    Console.Write("Age: ");
                    var ag = Convert.ToInt32(Console.ReadLine());
                    Console.Write("salary: ");
                    var sal =Convert.ToDouble( Console.ReadLine());
                    Console.Write("joinyear: ");
                    var jyear = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var staff = new Staff(nam, ag, sal, jyear);
                        database.AddStaff(staff);

                    }
                    catch(Exception exep)
                    {
                        Console.WriteLine(exep.Message);
                    }
                    break;

                case 3:
                    Console.Write("Name: ");
                    var n = Console.ReadLine();
                    Console.Write("Age: ");
                    var a = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        var person = new Person(n, a);
                        database.AddPerson(person);
                    }
                    catch (Exception excep)
                    {
                        Console.WriteLine(excep.Message);
                    }
                    break;

                case 4:
                    database.printAll();
                    break;

                default:
                    return;


            }
        }




    }
}

