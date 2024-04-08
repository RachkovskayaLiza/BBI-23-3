class Diving
{
    protected string _Surname;
    protected double[,] _Ball;
    protected static string _Discipline = "";
    protected string Discipline;


    public string D => Discipline;
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
    public Diving(string surname, double[,] Ball)
    {
        _Surname = surname;
        _Ball = Ball;
    }
    public virtual void Print()
    {
        Console.WriteLine("Дисциплина: {0}", Discipline);


        Console.Write("Имя   | Оценка1  | Оценка2 | Оценка3 | Оценка4 | Оценка5 | Total\n");
        Console.Write(_Surname + " ");

        for (int j = 0; j < 5; j++)
        {
            Console.Write("{0}({1})   | ", _Ball[0, j], _Ball[1, j]);
        }
        Console.WriteLine("{0}", CalculateTotalBall());

    }
    private double CalculateTotalBall()
    {
        double sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum += _Ball[0, i] + _Ball[1, i];
        }
        return sum;
    }



}
class ThreeMeterDiving : Diving
{
    public ThreeMeterDiving(string surname, double[,] Ball) : base(surname, Ball)
    {
        _Discipline = "3 meter";
        Discipline = _Discipline;
    }

}

class FiveMeterDiving : Diving
{

    public FiveMeterDiving(string surname, double[,] Ball) : base(surname, Ball)
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

        Diving[] divers1 = new Diving[5]
        {
            new ThreeMeterDiving("Прыгун1", ball1),
            new ThreeMeterDiving("Прыгун2", ball2),
            new ThreeMeterDiving("Прыгун3", ball3),
            new FiveMeterDiving("Прыгун4", ball4),
            new FiveMeterDiving("Прыгун5", ball5)
        };

        Sort(divers1);

        Console.WriteLine("Итоговый протокол соревнований:");

        for (int i = 0; i < divers1.Length; i++)
        {
            divers1[i].Print();
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

