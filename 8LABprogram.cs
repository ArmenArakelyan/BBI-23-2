//2
using System;

public abstract class MessageEncryption
{
    public abstract string Encrypt(string message);
    public abstract string Decrypt(string encryptedMessage);
}

public class ReverseEncryption : MessageEncryption
{
    private char[] charArray;

    public override string Encrypt(string message)
    {
        charArray = message.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public override string Decrypt(string encryptedMessage)
    {
        charArray = encryptedMessage.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public override string ToString()
    {
        return "Обратное шифрование";
    }
}

class Program
{
    static void Main()
    {
    string originalMessage = "Hello, Mark Anatolyevich!";

    ReverseEncryption encryption = new ReverseEncryption();
    string encryptedMessage = encryption.Encrypt(originalMessage);
    Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage}");

    string decryptedMessage = encryption.Decrypt(encryptedMessage);
    Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");
}
}
//4
using System;
class Sentence
{
    private string _sentence;

    public Sentence(string sentence)
    {
        _sentence = sentence;
    }

    public int CalculateComplexity()
    {
        if (string.IsNullOrEmpty(_sentence))
        {
            return 0;
        }

        int wordCount = _sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int punctuationCount = 0;
        foreach (char c in _sentence)
        {
            if (char.IsPunctuation(c))
            {
                punctuationCount++;
            }
        }

        return wordCount + punctuationCount;
    }
}

class Program
{
    static void Main()
    {
        string sentence = "Здравству��те, всё работает!!!";
        Sentence sentenceObj = new Sentence(sentence);
        int complexity = sentenceObj.CalculateComplexity();
        Console.WriteLine($"Сложность предложения: {complexity}");
    }
}
//6
using System;
using System.Text.RegularExpressions;

class TextAnalyzer
{
    private string text;

    public TextAnalyzer(string inputText)
    {
        text = inputText;
    }

    public void SetText(string inputText)
    {
        text = inputText;
    }

    public string GetText()
    {
        return text;
    }

    public void AnalyzeSyllables()
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        int[] syllableCount = new int[6]; // Массив для подсчета количества слов с определенным количеством слогов(это так, для себя, чтобы не защите не забыть) )

        foreach (string word in words)
{
int count = Regex.Matches(word, "[аеёиоуыэюяaeiouy]+", RegexOptions.IgnoreCase).Count;
if (count <= 5)
{
syllableCount[count]++;
}
}

for (int i = 1; i < syllableCount.Length; i++)
{
Console.WriteLine($"Слов с {i} слогом: {syllableCount[i]}");
}
    }
}

class Program
{
    static void Main()
    {
        string text = "Представим, что тут написан умный длинный текст";

        TextAnalyzer analyzer = new TextAnalyzer(text);
        analyzer.AnalyzeSyllables();
    }
}
//8
using system;

class textprocessor
{
    private string text;
    private int maxlength;
    private int currentindex;

    public textprocessor(string text, int maxlength)
    {
        this.text = text;
        this.maxlength = maxlength;
        this.currentindex = 0;
    }

    public void processtext()
    {
        while (currentindex < text.length)
        {
            if (text.length - currentindex <= maxlength)
            {
                console.writeline(text.substring(currentindex));
                break;
            }

            int spaceindex = text.lastindexof(' ', math.min(currentindex + maxlength, text.length - 1), maxlength - 1);
            if (spaceindex <= currentindex)
            {
                spaceindex = currentindex + maxlength;
            }

            console.writeline(text.substring(currentindex, spaceindex - currentindex));
            currentindex = spaceindex + 1;
        }
    }
}

class program
{
    static void main()
    {
        string text = "после твоего имени – джеральдина – следует моя фамилия – чаплин. с этой фамилией более сорока лет я смешил людей на земле. но плакал я больше, нежели они смеялись." +
            "джеральдина, в мире, в котором ты живешь, существуют не одни только танцы и музыка! в полночь, когда ты выходишь из огромного зала, ты можешь забыть богатых поклонников, но не забывай спросить у шофера такси, который повезет тебя домой, о его жене." +
            "и если она беременна, если у них нет денег на пеленки для будущего ребенка, положи деньги ему в карман. но всем другим плати строго по счету." +
            "время от времени езди в метро или на автобусе, ходи пешком и осматривай город.приглядывайся к людям! смотри на вдов и сирот! и хотя бы один раз в день говори себе: «я такая же, как они. " +
            "с этим письмом посылаю тебе чековую книжку, чтобы ты могла тратить сколько пожелаешь. но когда истратишь два франка, не забудь напомнить себе, что третья монета — не твоя. она должна принадлежать незнакомому человеку, который в ней нуждается.";
        int maxlength = 50;

        textprocessor processor = new textprocessor(text, maxlength);
        processor.processtext();
    }
}
//9
using System;
using System.Collections.Generic;
class Compression
{
    private Dictionary<string, char> codeTable = new Dictionary<string, char>();
    private char code = 'P';

    public void CompressText(string text)
    {
        for (int i = 0; i < text.Length - 1; i++)
        {
            string sequence = text.Substring(i, 2);
            if (!codeTable.ContainsKey(sequence))
            {
                codeTable.Add(sequence, code);
                code++;
            }
            i++;
        }

        string compressedText = "";
        for (int i = 0; i < text.Length - 1; i++)
        {
            string sequence = text.Substring(i, 2);
            compressedText += codeTable[sequence];
            i++;
        }

        Console.WriteLine("Текст до сжатия: " + text);
        Console.WriteLine("Таблица кодов:");
        foreach (var item in codeTable)
{
Console.WriteLine(item.Key + " : " + item.Value);
}
Console.WriteLine("Сжатый текст: " + compressedText);
    }
}

class Program
{
    static void Main()
    {
        string text = "мама, тетерев, ветер";
        Compression compressor = new Compression();
        compressor.CompressText(text);
    }
}
//10
using System;
using System.Collections.Generic;

class CodeTable
{
    private Dictionary<string, char> table;

    public CodeTable()
    {
        table = new Dictionary<string, char>();
    }

    public void AddCode(string sequence, char code)
    {
        if (!table.ContainsKey(sequence))
        {
            table.Add(sequence, code);
        }
    }

    public string CompressText(string text)
    {
        string compressedText = "";
        for (int i = 0; i < text.Length - 1; i++)
        {
            string sequence = text.Substring(i, 2);
            compressedText += table[sequence];
            i++;
        }
        return compressedText;
    }

    public string DecodeText(string compressedText)
    {
        string decodedText = "";
        for (int i = 0; i < compressedText.Length; i++)
        {
            string sequence = compressedText.Substring(i, 1);
            foreach (var pair in table)
            {
                if (pair.Value.ToString() == sequence)
                {
                    decodedText += pair.Key;
                    break;
                }
            }
        }
        return decodedText;
    }

    public void PrintCodes()
    {
        Console.WriteLine("Таблица кодов:");
        foreach (var item in table)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}

class Program
{
    static void Main()
    {
        string text = "мама, тетерев, ветер";
        CodeTable codeTable = new CodeTable();
        char code = 'P';

        for (int i = 0; i < text.Length - 1; i++)
        {
            string sequence = text.Substring(i, 2);
            codeTable.AddCode(sequence, code);
            code++;
            i++;
        }

        string compressedText = codeTable.CompressText(text);

        Console.WriteLine("Текст до сжатия: " + text);
        codeTable.PrintCodes();
        Console.WriteLine("Сжатый текст: " + compressedText);

        string decodedText = codeTable.DecodeText(compressedText);

        Console.WriteLine("Декодированный текст: " + decodedText);
    }
}