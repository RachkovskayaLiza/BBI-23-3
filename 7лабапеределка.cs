using System.Data;

class Diver
{
    private string _Surname;
    private double[,] _Ball;

    public string Surname => _Surname;

    public double TotalBall
    {
        get
        {
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += _Ball[0, i] + _Ball[1, i];
            }
            return sum;
        }
    }
    public Diver(string surname, double[,] Ball)
    {
        _Surname = surname;
        _Ball = Ball;
    }
    public void Print()
    {
        Console.Write("{0,-10} ", Surname);
        for (int i = 0; i < 5; i++)
        {
            Console.Write("{0}({1}), ", _Ball[0, i], _Ball[1, i]);

        }
        Console.WriteLine("Total: {0}", TotalBall);
    }


}

class Diving
{

    protected static string _Discipline = "";
    protected string Discipline;
    protected Diver[] _diver;

    public string D => Discipline;



    public Diving(Diver[] a)
    {
        _diver = a;

    }
    public virtual void Print()
    {
        Console.WriteLine("Дисциплина: {0}", Discipline);

        foreach (Diver diver in _diver)
        {
            diver.Print();
        }
    }


}
class ThreeMeterDiving : Diving
{
    public ThreeMeterDiving(Diver[] a) : base(a)
    {
        _Discipline = "3 meter";
        Discipline = _Discipline;
    }

}

class FiveMeterDiving : Diving
{

    public FiveMeterDiving(Diver[] a) : base(a)
    {
        _Discipline = "5 meter";
        Discipline = _Discipline;
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        double[,] ball1 = { { 8.5, 8.0, 9.0, 9.5, 8.5 }, { 7.0, 8.5, 7.5, 8.0, 6.5 } };
        double[,] ball2 = { { 7.5, 8.0, 7.5, 8.0, 7.0 }, { 6.5, 7.0, 6.0, 7.5, 6.0 } };
        double[,] ball3 = { { 6.5, 7.0, 7.0, 7.5, 6.5 }, { 8.0, 7.5, 7.0, 8.5, 7.5 } };
        double[,] ball4 = { { 7.0, 6.5, 8.0, 6.5, 8.5 }, { 8.0, 6.0, 7.5, 6.0, 7.0 } };
        double[,] ball5 = { { 8.0, 8.5, 7.5, 7.0, 8.0 }, { 6.0, 6.5, 7.0, 6.5, 7.5 } };
        Diver[] divers1 = new Diver[5]
        {
            new Diver("Иванов",ball1),
            new Diver("Петров",ball2),
            new Diver("Сидоров",ball3),
            new Diver("Козлов",ball4),
            new Diver("Захаров",ball5)

        };
        Diver[] divers2 = new Diver[5]
        {
           new Diver("Иудов",ball1),
            new Diver("Давыдов",ball2),
            new Diver("Да",ball3),
            new Diver("Нет",ball4),
            new Diver("Ок",ball5)
        };
        Diving[] divings = { new ThreeMeterDiving(divers1), new FiveMeterDiving(divers2) };

        Sort(divings);

        Console.WriteLine("Итоговый протокол соревнований:");

        for (int i = 0; i < divings.Length; i++)
        {
            divings[i].Print();
        }
        Console.ReadKey();
    }
    static void Sort(Diving[] divers)
    {
        for (int i = 0; i < divers.Length - 1; i++)
        {
            for (int j = i + 1; j < divers.Length; j++)
            {
                if (divers[j].D.CompareTo(divers[i].D) < 0)
                {
                    (divers[j], divers[i]) = (divers[i], divers[j]);
                }
            }
        }
    }

}

