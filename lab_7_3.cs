using System;

public class Team
{
    protected int[] results;

    public Team(int[] results)
    {
        this.results = results;
    }

    public virtual int SumPoints()
    {
        int points = 0;
        foreach (int result in results)
        {
            switch (result)
            {
                case 1:
                    points += 5;
                    break;
                case 2:
                    points += 4;
                    break;
                case 3:
                    points += 3;
                    break;
                case 4:
                    points += 2;
                    break;
                case 5:
                    points += 1;
                    break;
                default:
                    points += 0;
                    break;
            }
        }
        return points;
    }
}

public class FemaleTeam : Team
{
    public FemaleTeam(int[] results) : base(results) { }
}

public class MaleTeam : Team
{
    public MaleTeam(int[] results) : base(results) { }
}

class Program
{
    static void Main()
    {
        int[] resultsTeam1 = { 1, 2, 3, 4, 5, 6 };
        int[] resultsTeam2 = { 7, 8, 9, 10, 11, 12 };
        int[] resultsTeam3 = { 13, 14, 15, 16, 17, 18 };

        Team femaleTeam = new FemaleTeam(resultsTeam1);
        Team maleTeam = new MaleTeam(resultsTeam2);
        Team anotherFemaleTeam = new FemaleTeam(resultsTeam3);

        int pointsFemaleTeam = femaleTeam.SumPoints();
        int pointsMaleTeam = maleTeam.SumPoints();
        int pointsAnotherFemaleTeam = anotherFemaleTeam.SumPoints();

        Team winningTeam = pointsFemaleTeam > pointsMaleTeam ? femaleTeam : maleTeam;

        if (winningTeam.SumPoints() < pointsAnotherFemaleTeam)
        {
            winningTeam = anotherFemaleTeam;
        }

        Console.WriteLine($"команда победителей набрала  {winningTeam.SumPoints()} баллов.");

        Console.ReadKey();
    }
}
