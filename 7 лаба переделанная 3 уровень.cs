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
        int[] resultsTeam1m = { 1, 2, 3, 4, 5, 6 };
        int[] resultsTeam2m = { 7, 8, 9, 10, 11, 12 };
        int[] resultsTeam3m = { 13, 14, 15, 16, 17, 18 };
        int[] resultsTeam4w = { 1, 3, 4, 7, 10, 12 };
        int[] resultsTeam5w = { 2, 5, 6, 8, 9, 11 };
        int[] resultsTeam6w = { 17, 16, 15, 14, 13, 18 };


        Team[] femaleTeam ={
            new FemaleTeam(resultsTeam6w),
             new FemaleTeam(resultsTeam4w),
              new FemaleTeam(resultsTeam5w)
        };
        Team[] maleTeam ={
            new MaleTeam(resultsTeam1m),
            new MaleTeam(resultsTeam3m),
            new MaleTeam(resultsTeam2m)
        };



        int bestFemaleScore = BestScore(femaleTeam)[0];
        int bestMenScore = BestScore(maleTeam)[0];

        Team winningTeam = bestFemaleScore > bestMenScore ? femaleTeam[BestScore(femaleTeam)[1]] : maleTeam[BestScore(maleTeam)[1]];


        Console.WriteLine($"команда победителей набрала  {winningTeam.SumPoints()} баллов.");

        Console.ReadKey();
    }
    static int[] BestScore(Team[] a)
    {
        int max = 0;
        int imax = 0;
        for (int i = 0; i < a.Length; i++)
        {

            if (a[i].SumPoints() > max)
            {
                max = a[i].SumPoints();
                imax = i;
            }

        }
        int[] b = { max, imax };
        return b;
    }
}

