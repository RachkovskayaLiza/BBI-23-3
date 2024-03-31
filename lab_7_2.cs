abstract class Diving
{
    protected string _Discipline;

    public string Discipline => _Discipline;

    public Diving(string discipline)
    {
        _Discipline = discipline;
    }

    public abstract void Print();
}

class ThreeMeterDiving : Diving
{
    private double[,] _Ball;

    public ThreeMeterDiving(string discipline, double[,] Ball) : base(discipline)
    {
        _Ball = Ball;
    }

    public override void Print()
    {
        Console.WriteLine("Дисциплина: {0}", Discipline);
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Имя  | Оценка1 | Оценка2 | Оценка3 | Оценка4 | Оценка5 | Total\n");
            Console.Write("{0,-10}-", Discipline);
            for (int j = 0; j < 5; j++)
            {
                Console.Write("{0}({1}), ", _Ball[0, j], _Ball[1, j]);
            }
            Console.WriteLine("Total: {0}", CalculateTotalBall());
        }
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

class FiveMeterDiving : Diving
{
    private double[,] _Ball;

    public FiveMeterDiving(string discipline, double[,] Ball) : base(discipline)
    {
        _Ball = Ball;
    }

    public override void Print()
    {
        Console.WriteLine("Дисциплина: {0}", Discipline);
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Имя  | Оценка1 | Оценка2 | Оценка3 | Оценка4 | Оценка5 | Total\n");
            Console.Write("{0,-10}-", Discipline);
            for (int j = 0; j < 5; j++)
            {
                Console.Write("{0}({1}), ", _Ball[0, j], _Ball[1, j]);
            }
            Console.WriteLine("Total: {0}", CalculateTotalBall());
        }
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

internal class Program
{
    static void Main(string[] args)
    {
        double[,] ball1 = { { 8.5, 8.0, 9.0, 9.5, 8.5 }, { 7.0, 8.5, 7.5, 8.0, 6.5 } };
        double[,] ball2 = { { 7.5, 8.0, 7.5, 8.0, 7.0 }, { 6.5, 7.0, 6.0, 7.5, 6.0 } };
        double[,] ball3 = { { 6.5, 7.0, 7.0, 7.5, 6.5 }, { 8.0, 7.5, 7.0, 8.5, 7.5 } };
        double[,] ball4 = { { 7.0, 6.5, 8.0, 6.5, 8.5 }, { 8.0, 6.0, 7.5, 6.0, 7.0 } };
        double[,] ball5 = { { 8.0, 8.5, 7.5, 7.0, 8.0 }, { 6.0, 6.5, 7.0, 6.5, 7.5 } };

        Diving[] divers = new Diving[5]
        {
            new ThreeMeterDiving("Прыжки в воду с 3 метровой вышки", ball1),
            new ThreeMeterDiving("Прыжки в воду с 3 метровой вышки", ball2),
            new ThreeMeterDiving("Прыжки в воду с 3 метровой вышки", ball3),
            new FiveMeterDiving("Прыжки в воду с 5 метровой вышки", ball4),
            new FiveMeterDiving("Прыжки в воду с 5 метровой вышки", ball5)
        };

        Sort(divers);

        Console.WriteLine("Итоговый протокол соревнований:");

        for (int i = 0; i < divers.Length; i++)
        {
            divers[i].Print();
        }
        Console.ReadKey();
    }

    static void Sort(Diving[] divers)
    {
        for (int i = 0; i < divers.Length - 1; i++)
        {
            for (int j = i + 1; j < divers.Length; j++)
            {
                if (divers[j].Discipline.CompareTo(divers[i].Discipline) < 0)
                {
                    (divers[j], divers[i]) = (divers[i], divers[j]);
                }
            }
        }
    }
}