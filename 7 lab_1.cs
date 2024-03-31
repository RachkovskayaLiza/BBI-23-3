//5



abstract class Student
{
    protected string _Name;
    protected int _Grade;
    protected int _Propuski;

    public int Grade => _Grade; // read- only property
    public int Propuski => _Propuski; // read-only property
   


    public Student(string Name, int Grade, int Propuski)
    {
        _Name = Name;
        _Grade = Grade;
        _Propuski = Propuski;
    }

    public abstract void Print();
}

class ComputerScienceStudent : Student
{
    public ComputerScienceStudent(string Name, int Grade, int Propuski) : base(Name, Grade, Propuski)
    {
    }

    public override void Print()
    {
        Console.WriteLine("{0,-5}|{1,-8}|{2,-3}", _Name, Grade, Propuski);
    }
}

class MathStudent : Student
{
    public MathStudent(string Name, int Grade, int Propuski) : base(Name, Grade, Propuski)
    {
    }

    public override void Print()
    {
        Console.WriteLine("{0,-5}|{1,-8}|{2,-3}", _Name, Grade, Propuski);
    }
}

internal class Program
{
    static void Main(string[]  args)
    {
        Student[] computerScienceStudents  = new Student[3]
        {
            new ComputerScienceStudent("Alisa", 2, 4),
            new ComputerScienceStudent("Liza", 4, 2),
            new ComputerScienceStudent("Anna", 2, 6)
        };

        Student [] mathStudents = new Student[3]
        {
            new MathStudent("Artem", 5, 1),
            new MathStudent("Mark", 5, 4),
            new MathStudent("Ivan", 2, 0)
        };

        Console.WriteLine("Computer Science Students:");
        Console.WriteLine("Имя  | Оценка | Пропуски ");
        foreach (var student in computerScienceStudents)
        {
            student.Print();
        }

        Console.WriteLine("\nMath Students:");
        Console.WriteLine("Имя  | Оценка | Пропуски ");
        foreach (var student in mathStudents)
        {
            student.Print();
        }

        Console.ReadKey();
    }
}