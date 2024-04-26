using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text;
        protected set => text = value;
    }

    public virtual void Solution() { }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    private List<string> answer;
    public List<string> Answer
    {
        get => answer;
        protected set => answer = value;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        answer = new List<string>();
    }
    public override void Solution()
    {
        string[] sentenses = text.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in sentenses)
        {
            string[] word = s.Split(" ,-!.:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            answer.Add(word[word.Length - 1]);
        }

    }

    public override string ToString()
    {
        Solution();
        if (answer == null) return "";
        return string.Join(",", answer.ToArray()); ;
    }
}
class Task2 : Task
{
    private string answer;
    public string Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        answer = "";

    }
    public override void Solution()
    {
        int mxWord = 0;
        string sentense = "";
        string[] sentenses = text.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in sentenses)
        {
            string[] word = s.Split(" ,-!.:;()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (mxWord < word.Length)
            {
                answer = s;
                mxWord = word.Length;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return answer;
    }
}

class Program
{
    static void Main()
    {
        string text = "A. A, fff, sss. Z (A 4).";
        Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2304151"; //путь до рабочего стола
        string folderName = "Answer";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "cw2_1.json";
        string fileName2 = "cw2_2.json";


        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName1))
        {
            File.Create(fileName1);
        }
        if (!File.Exists(fileName2))
        {
            File.Create(fileName2);
        }

    }
}