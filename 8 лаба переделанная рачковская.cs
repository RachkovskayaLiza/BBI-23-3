using System;
using System.Text.RegularExpressions;
abstract class Task
{
    protected string text;
    public Task(string text) { this.text = text; }

    protected string checker = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected virtual void Solution() { }
}

class Task_1 : Task
{
    string answer;
    public Task_1(string text) : base(text) { answer = ""; }
    public override string ToString()
    {
        Solution();
        return answer;
    }

    private string ReverseText(string txt)
    {
        string result = "";
        for (int i = 0; i < txt.Length; ++i)
        {
            string word = "";
            if (checker.Contains(txt.ToUpper()[i]))
            {
                word += txt[i];
                while (i + 1 < txt.Length && checker.Contains(txt.ToUpper()[i + 1]))
                {
                    word += txt[i + 1];
                    ++i;
                }
            }
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            word = new string(arr);
            if (word != "")
                result += word;
            else
                result += txt[i];
        }
        return result;
    }
    protected void Solution()
    {
        string tmp = ReverseText(text);
        answer = tmp + '\n' + ReverseText(tmp);
    }

}

class Task_2 : Task
{
    int count;
    public Task_2(string text) : base(text) { count = 0; }
    public override string ToString()
    {
        Solution();
        return Convert.ToString(count);
    }
    protected void Solution()
    {
        char[] charSeparators = new char[] { ' ', ',', '-', '!', '.', ':', ';', '(', ')' };
        count = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
        foreach (var i in text)
        {
            if (" ,-!.:;()".Contains(i))
            {
                ++count;
            }
        }

    }
}

class Task_3 : Task
{
    int[] count;
    public Task_3(string text) : base(text) { count = new int[40]; }
    public override string ToString()
    {
        Solution();
        string parse = "";
        for (int i = 0; i < 40; ++i)
        {
            if (count[i] != 0)
            {
                parse += i.ToString() + "слогов : " + count[i].ToString() + '\n';
            }
        }
        return parse;
    }
    protected void Solution()
    {
        char[] charSeparators = new char[] { ' ', ',', '-', '!', '.', ':', ';', '(', ')' };
        string[] s = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        string vowels = "auoyieаиеёуояыюэ";
        foreach (var i in s)
        {
            int syllable = 0;
            for (int j = 0; j < i.Length; ++j)
            {
                if (vowels.Contains(i.ToLower()[j]))
                    ++syllable;
            }
            if (syllable > 0) count[syllable]++;
        }

    }
}

class Task4 : Task
{
    private string customAnswer;
    public string CustomAnswer
    {
        get => customAnswer;
        protected set => customAnswer = value;
    }
    public Task4(string customText) : base(customText)
    {
        customAnswer = "";
    }
    protected override void Solution()
    {
        int tempLength = 0;
        int count, spacesPerWord, remainingSpaces;
        string[] customWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int lastWordIndex = 0;
        for (int i = 0; i < customWords.Length; ++i)
        {
            tempLength += customWords[i].Length + 1;

            if (tempLength >= 50)
            {
                tempLength -= (customWords[i].Length + 2);
                count = 50 - tempLength;
                spacesPerWord = count / (i - lastWordIndex - 1);
                remainingSpaces = count % (i - lastWordIndex - 1);
                for (int j = lastWordIndex; j < i; ++j)
                {
                    customAnswer += customWords[j];
                    customAnswer += " ";
                    for (int k = 0; k < spacesPerWord; ++k)
                    {
                        customAnswer += " ";
                    }
                    if (remainingSpaces > 0)
                    {
                        customAnswer += " ";
                        --remainingSpaces;
                    }
                }
                customAnswer += "\n";
                lastWordIndex = i;
                --i;
                tempLength = 0;
            }
        }
        if (lastWordIndex != customWords.Length - 1)
        {
            int i = customWords.Length - 1;
            tempLength -= 1;
            count = 50 - tempLength;
            spacesPerWord = count / (i - lastWordIndex);
            remainingSpaces = count % (i - lastWordIndex);
            for (int j = lastWordIndex; j <= i; ++j)
            {
                customAnswer += customWords[j];
                customAnswer += " ";
                for (int k = 0; k < spacesPerWord; ++k)
                {
                    customAnswer += " ";
                }
                if (remainingSpaces > 0)
                {
                    customAnswer += " ";
                    --remainingSpaces;
                }
            }
            customAnswer += "\n";
        }
    }

    public override string ToString()
    {
        Solution();
        return Convert.ToString(customAnswer);
    }
}
class Task_5 : Task
{
    private string result;
    private string modifiedText;
    Dictionary<char, string> encodingMap;
    int startCode = 100;
    public string Result
    {
        get => result;
    }
    public Dictionary<char, string> EncodingMap
    {
        get => encodingMap;
    }
    public Task_5(string inputText) : base(inputText)
    {
        result = "";
        encodingMap = new Dictionary<char, string>();
        modifiedText = inputText.ToLower();
        Solution();
    }

    private bool IterateAndReplace()
    {
        Dictionary<string, int> pairCounter = new Dictionary<string, int>();
        for (int i = 0; i < modifiedText.Length; i++)
        {
            if (i + 1 < modifiedText.Length && checker.Contains(modifiedText.ToUpper()[i]) && checker.Contains(modifiedText.ToUpper()[i + 1]))
            {
                string pair = Convert.ToString(modifiedText[i]) + modifiedText[i + 1];
                if (pairCounter.ContainsKey(pair))
                {
                    pairCounter[pair]++;
                }
                else
                {
                    pairCounter[pair] = 1;
                }
                if (modifiedText[i] == modifiedText[i + 1] && i + 2 < modifiedText.Length && modifiedText[i + 1] == modifiedText[i + 2])
                    ++i;
            }
        }
        string mostFrequentPair = "";
        int maxCount = 0;
        foreach (string pair in pairCounter.Keys)
        {
            if (pairCounter[pair] > maxCount)
            {
                maxCount = pairCounter[pair];
                mostFrequentPair = pair;
            }
        }
        string temp = "";
        for (int i = 0; i < modifiedText.Length; i++)
        {
            if (i + 1 < modifiedText.Length && Convert.ToString(modifiedText[i]) + modifiedText[i + 1] == mostFrequentPair)
            {
                ++i;
                continue;
            }
            temp += modifiedText[i];
        }
        modifiedText = temp;
        while (text.Contains((char)startCode) || encodingMap.ContainsKey((char)startCode))
        {
            ++startCode;
        }
        encodingMap[(char)startCode] = mostFrequentPair;
        return true;
    }
    protected override void Solution()
    {
        for (int i = 0; i < 5; ++i)
        {
            IterateAndReplace();
        }
        result = text;
        foreach (var item in encodingMap)
        {
            result = result.Replace(item.Value, Convert.ToString(item.Key));
        }
    }
    public override string ToString()
    {
        return string.Join(Environment.NewLine, encodingMap) + '\n' + result + '\n';
    }
}
class Task_6 : Task
{
    private string result;
    Dictionary<char, string> mapping;
    public string Result
    {
        get => result;
    }
    public Task_6(string inputText, Dictionary<char, string> _mapping) : base(inputText)
    {
        result = "";
        mapping = _mapping;
    }

    protected override void Solution()
    {
        foreach (var character in text)
        {
            if (mapping.ContainsKey(character))
            {
                result += mapping[character];
            }
            else
            {
                result += character;
            }
        }
    }
    public override string ToString()
    {
        Solution();
        return result;
    }
}

class Program
{
    public static void Main()
    {
        string text = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
        string sentense = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets.";
        Task_1 task1 = new Task_1(text);
        Task_2 task_2 = new Task_2(sentense);
        Task_3 task_3 = new Task_3(text);
        Task4 task_4 = new Task4(text);
        Task_5 task_5 = new Task_5(text);
        Task_6 task6 = new Task_6(text, task_5.EncodingMap);

        Console.WriteLine(task1);
        Console.WriteLine(task_2);
        Console.WriteLine(task_3);
        Console.WriteLine(task_4);
        Console.WriteLine(task_5);
        Console.WriteLine(task6);
    }
}