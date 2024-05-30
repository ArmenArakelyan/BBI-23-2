using lab9_3.Serializers;
using System;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using ProtoBuf;
using System.IO;

[ProtoContract]
[ProtoInclude(1, typeof(WomenTeam))]
[ProtoInclude(2, typeof(MenTeam))]
public abstract class Team
{
    [ProtoMember(3)]
    public string _name;
    [ProtoMember(4)]
    public double[] _results;
    [ProtoMember(5)]
    public string Name
    {
        get => _name;
        set => _name = value ?? string.Empty;
    }
    [ProtoMember(6)]
    public double[] Results
    {
        get => _results;
        set => _results = value ?? new double[6];
    }
    public Team() { }
    public Team(string name, double[] results)
    {
        _name = name;
        _results = results;
    }
    public virtual void Print()
    {
        Console.WriteLine($"{Name}:  {string.Join(", ", Results)}");
    }
}

[ProtoContract]
public class WomenTeam : Team
{
    [ProtoMember(7)]
    public string UniformColor { get; set; }

    public WomenTeam() : base() { }
    public WomenTeam(string name, double[] results, string uniformColor) : base(name, results)
    {
        UniformColor = uniformColor; //новое поле UniformColor с доп параметром
    }
    public override void Print()
    {
        Console.WriteLine($"Женская команда: {_name}:  {string.Join(", ", Results)}, Цвет униформы: {UniformColor}");   
    }
}

[ProtoContract]
public class MenTeam : Team
{
    [ProtoMember(7)]
    public int TourNumber { get; set; }

    public MenTeam() : base() { }
    public MenTeam(string name, double[] results, int tourNumber) : base(name, results)
    {
        TourNumber = tourNumber; //новое поле TourNumber с доп параметром
    }
    public override void Print()
    {
        Console.WriteLine($"Мужская команда: {_name}: {string.Join(", ", Results)}, Номер турнира: {TourNumber}");
    }
}

class Program
{
    static void Main()
    {
        WomenTeam[] womenTeams = new WomenTeam[]
        {
            new WomenTeam("TeamA", new double[] { 1, 2, 3, 4, 5, 6 }, "Red"),
            new WomenTeam("TeamB", new double[] { 7, 8, 9, 10, 11, 12 }, "Blue"),
            new WomenTeam("TeamC", new double[] { 13, 14, 15, 16, 17, 18 }, "Green")
        };
        MenTeam[] menTeams = new MenTeam[]
        {
            new MenTeam("TeamX", new double[] { 1, 2, 3, 4, 5, 6 }, 1),
            new MenTeam("TeamY", new double[] { 7, 8, 9, 10, 11, 12 }, 2),
            new MenTeam("TeamZ", new double[] { 13, 14, 15, 16, 17, 18 }, 3)
        };

        Serial[] serializers = new Serial[3]
        {
            new JSONManager(),
            new BinManager(),
            new XMLManager()
        };

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, "Task 3");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        string[] files = new string[3]
        {
            "woman.json",
            "woman.bin",
            "woman.xml",
        };
        for (int i = 0; i < files.Length; i++)
        {
            serializers[i].Write(womenTeams, Path.Combine(path, files[i]));
        }
        for (int i = 0; i < files.Length; i++)
        {
            womenTeams = serializers[i].Read<WomenTeam[]>(Path.Combine(path, files[i]));
            foreach (WomenTeam woman in womenTeams)
            {
                woman.Print();
            }
        }

        string[] filess = new string[3]
        {
            "man.json",
            "man.bin",
            "man.xml",
        };
        for (int i = 0; i < filess.Length; i++)
        {
            serializers[i].Write(menTeams, Path.Combine(path, filess[i]));
        }
        for (int i = 0; i < filess.Length; i++)
        {
            menTeams = serializers[i].Read<MenTeam[]>(Path.Combine(path, filess[i]));
            foreach (MenTeam man in menTeams)
            {
                man.Print();
            }
        }
    }
}







//FindTopTeam(womenTeams);
//FindTopTeam(menTeams);
//Team winner = GetWinner(womenTeams, menTeams);
//Console.WriteLine("Победитель:");
//winner.Print();

//static void FindTopTeam(Team[] teams)
//{
//    int d = teams.Length / 2;
//    Team temp;
//    while (d >= 1)
//    {
//        for (int i = d; i < teams.Length; i++)
//        {
//            int j = i;
//            while (j >= d && teams[j - d].BestTeam < teams[j].BestTeam)
//            {
//                temp = teams[j];
//                teams[j] = teams[j - d];
//                teams[j - d] = temp;
//                j = j - d;
//            }
//        }
//        d = d / 2;
//    }
//}
//    static Team GetWinner(Team[] womenTeams, Team[] menTeams)
//    {
//        Team winnerWomen = womenTeams[0];
//        foreach (Team team in womenTeams)
//        {
//            if (team.Count > winnerWomen.Count)
//            {
//                winnerWomen = team;
//            }
//        }

//        Team winnerMen = menTeams[0];
//        foreach (Team team in menTeams)
//        {
//            if (team.Count > winnerMen.Count)
//            {
//                winnerMen = team;
//            }
//        }
//        if (winnerWomen.Count > winnerMen.Count)
//        { return winnerWomen; }
//        else
//        { return winnerMen; }
//    }
//}



/*
[ProtoBuf.ProtoContract()]
[ProtoBuf.ProtoInclude(1, typeof(WomenTeam))]
[ProtoBuf.ProtoInclude(1, typeof(MenTeam))]
class Team
{
    private string _name;
    private double[] _results = new double[6];
    private int _count = 0;
    private int _bestTeam = 0;

    public Team(string name, double[] results)
    {
        _name = name;
        _results = results;
        for (int i = 0; i < _results.Length; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (results[i] == j)
                {
                    _count += 6 - j;
                }
            }
            if (results[i] == 1)
            {
                _bestTeam = 1;
            }
        }
    }

    public int BestTeam => _bestTeam;
    public int Count => _count;
    public string Name => _name;

    public void Print()
    {
        Console.WriteLine($"{_name} {_count}");
    }
}

class WomenTeam : Team
{
    public WomenTeam(string name, double[] results) : base(name, results)
    {
    }
}

class MenTeam : Team
{
    public MenTeam(string name, double[] results) : base(name, results)
    {
    }
}

class Program
{
    static void Main()
    {
        Team[] womenTeams = new WomenTeam[3];
        Team[] menTeams = new MenTeam[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Женская команда:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников команды:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            womenTeams[i] = new WomenTeam(name, results);
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Мужская команда:");
            string name = Console.ReadLine();
            Console.WriteLine("Места участников команды:");
            double[] results = new double[6];
            for (int j = 0; j < 6; j++)
            {
                results[j] = double.Parse(Console.ReadLine());
            }
            menTeams[i] = new MenTeam(name, results);
        }

        FindTopTeam(womenTeams);
        FindTopTeam(menTeams);

        Team winner = GetWinner(womenTeams, menTeams);

        Console.WriteLine("Победитель:");
        winner.Print();
    }

    static void FindTopTeam(Team[] teams)
    {
        int d = teams.Length / 2;
        Team temp;
        while (d >= 1)
        {
            for (int i = d; i < teams.Length; i++)
            {
                int j = i;
                while (j >= d && teams[j - d].BestTeam < teams[j].BestTeam)
                {
                    temp = teams[j];
                    teams[j] = teams[j - d];
                    teams[j - d] = temp;
                    j = j - d;
                }
            }
            d = d / 2;
        }
    }
    static Team GetWinner(Team[] womenTeams, Team[] menTeams)
    {
        Team winnerWomen = womenTeams[0];
        foreach (Team team in womenTeams)
        {
            if (team.Count > winnerWomen.Count)
            {
                winnerWomen = team;
            }
        }

        Team winnerMen = menTeams[0];
        foreach (Team team in menTeams)
        {
            if (team.Count > winnerMen.Count)
            {
                winnerMen = team;
            }
        }
        if (winnerWomen.Count > winnerMen.Count)
        { return winnerWomen; }
        else
        { return winnerMen; }
    }
}
*/