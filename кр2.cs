using System.Text.Json;
using System.Text.Json.Serialization;

namespace kr
{
    internal class Programm
    {
        abstract class Task
        {
            protected string text = "";
            public string Text
            {
                get => text;
                protected set => text = value;
            }
            public Task(string text)
            {
                this.text = text;
            }
        }
        class Task1 : Task
        {
            private int words_c;
            public int C
            {
                get => C;
                private set => C = value;
            }
            [JsonConstructor]
            public Task1(string text) : base(text)
            {
                string[] words = text.Split(new char[] { ' ', '.', '!', '"', '(', ')', '\'', ',', ';', ':', '–' });
                int c = 0;
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        c++;
                    }
                }
                words_c = c;

            }
            public override string ToString()
            {
                return words_c.ToString();
            }
        }
        class Task2 : Task
        {
            private string result;
            public string Result
            {
                get => result;
                private set => result = value;
            }
            [JsonConstructor]
            public Task2(string text) : base(text)
            {
                result = text;
                string[] preds = text.Split(new char[] { '.', '!', '?' });
                for (int i = 0; i < preds.Length; i++)
                {
                    if (preds[i] != "")
                    {
                        if (preds[i][0] == ' ')
                        {
                            preds[i] = preds[i].Substring(1);
                        }
                    }
                }
                string reversed_pred = "";
                for (int i = 1; i <= preds[0].Length; i++)
                {
                    reversed_pred += preds[0][preds[0].Length - i];
                }
                result = reversed_pred + result.Substring(reversed_pred.Length);
                int j = reversed_pred.Length;
                for (int i = 1; i < preds.Length; i++)
                {
                    reversed_pred = "";
                    if (preds[i].Length <= 1) { break; }
                    for (int z = 1; z <= preds[i].Length; z++)
                    {
                        reversed_pred += preds[i][preds[i].Length - z];
                    }
                    result = result.Substring(0, j + 1) + " " + reversed_pred + result.Substring(j + 2 + reversed_pred.Length);
                    j += preds[i].Length + 2;
                }
            }
            public override string ToString()
            {
                return result;
            }
        }
        class JsonIO
        {
            public static void Write<T>(T obj, string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, obj);
                }
            }
            public static T Read<T>(string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return JsonSerializer.Deserialize<T>(fs);
                }
            }
        }

        public static void Main(string[] args)
        {
            string s = "Шла Саша по шоссе и сосала сушку. Мороз и солнце день чудесный! А помнишь дядя ведь не даром.";
            Task[] tasks = {
            new Task1(s),
            new Task2(s)
            };
            string path = @"C:\Users\m2303638\Downloads";
            string folderName = "Solution";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName1 = "task_1.json";
            string fileName2 = "task_2.json";

            fileName1 = Path.Combine(path, fileName1);
            fileName2 = Path.Combine(path, fileName2);
            if (!File.Exists(fileName1))
            {
                var filec = File.Create(fileName1);
                filec.Close();
            }
            if (!File.Exists(fileName2))
            {
                var filec = File.Create(fileName2);
                filec.Close();
            }
            if (!File.Exists(fileName2)) // создаем файл, если его нет
            {
                JsonIO.Write<Task1>((Task1)tasks[0], fileName1);
                JsonIO.Write<Task2>((Task2)tasks[1], fileName2);
            }
            else
            {
                var t1 = JsonIO.Read<Task1>(fileName1);
                var t2 = JsonIO.Read<Task2>(fileName2);
                Console.WriteLine(t1);
                Console.WriteLine(t2);
            }
        }
    }
}
































