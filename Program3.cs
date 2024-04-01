using System;
using System.Collections.Generic;
using System.Linq;

class Group_Student
{
    private static double sum;
    private static int count;
    public string group_name;
    protected string surname;
    protected double mark1, mark2, mark3, mark4;

    public string Surname { get { return surname; } }

    public virtual double AverageMark()
    {
        return (mark1 + mark2 + mark3 + mark4) / 4;
    }

    public Group_Student(string surname, double mark1, double mark2, double mark3, double mark4)
    {
        this.surname = surname;
        this.mark1 = mark1;
        this.mark2 = mark2;
        this.mark3 = mark3;
        this.mark4 = mark4;
        group_name = "-";
    }
    public virtual double getAVG()
    {
        return Group_Student.sum / Group_Student.count;
    }
}

class BBI_23_4_Student : Group_Student
{
    private static double sum;
    private static int count;
    private double math, physics;
    public BBI_23_4_Student(string surname, double mark1, double mark2, double mark3, double mark4, double math, double physics) : base(surname, mark1, mark2, mark3, mark4)
    {
        this.math = math;
        this.physics = physics;
        sum += AverageMark();
        count++;
        group_name = "BBI_23_4";
    }
    public override double AverageMark()
    {
        return (mark1 + mark2 + mark3 + mark4 + math + physics) / 6;
    }
    public override double getAVG()
    {
        return BBI_23_4_Student.sum / BBI_23_4_Student.count;
    }
}
class BBI_23_5_Student : Group_Student
{
    private static double sum;
    private static int count;
    private double PE, chemistry;
    public BBI_23_5_Student(string surname, double mark1, double mark2, double mark3, double mark4, double PE, double chemistry) : base(surname, mark1, mark2, mark3, mark4)
    {
        this.PE = PE;
        this.chemistry = chemistry;
        sum += AverageMark();
        count++;
        group_name = "BBI-23-5";
    }
    public override double AverageMark()
    {
        return (mark1 + mark2 + mark3 + mark4 + PE + chemistry) / 6;
    }
    public override double getAVG()
    {
        return BBI_23_5_Student.sum / BBI_23_5_Student.count;
    }
}
class BBI_23_6_Student : Group_Student
{
    private static double sum;
    private static int count;
    private double english, spanish;
    public BBI_23_6_Student(string surname, double mark1, double mark2, double mark3, double mark4, double english, double spanish) : base(surname, mark1, mark2, mark3, mark4)
    {
        this.english = english;
        this.spanish = spanish;
        sum += AverageMark();
        count++;
        group_name = "BBI-23-6";
    }
    public override double AverageMark()
    {
        return (mark1 + mark2 + mark3 + mark4 + english + spanish) / 6;
    }
    public override double getAVG()
    {
        return BBI_23_6_Student.sum / BBI_23_6_Student.count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BBI_23_4_Student[] bbi_23_4 =
        {
            new BBI_23_4_Student("Васильев",5.0, 5.0, 4.0, 5.0, 3.0, 4.0),
            new BBI_23_4_Student("Иванов", 4.0, 4.0, 3.0, 4.0, 2.0, 3.0),
            new BBI_23_4_Student("Доржиев", 5.0, 4.0, 5.0, 5.0, 4.0, 5.0)
        };
        BBI_23_5_Student[] bbi_23_5 =
        {
            new BBI_23_5_Student("Цоктоев", 5.0, 4.0, 3.0, 5.0, 5.0, 4.0),
            new BBI_23_5_Student("Гатапов", 4.0, 3.0, 2.0, 3.0, 3.0, 4.0),
            new BBI_23_5_Student("Лыпкин", 5.0, 4.0, 3.0, 3.0, 3.0, 5.0)
        };
        BBI_23_6_Student[] bbi_23_6 =
        {
            new BBI_23_6_Student("Харханов", 5.0, 5.0, 5.0, 5.0, 5.0, 5.0),
            new BBI_23_6_Student("Жамсоев", 4.0, 4.0, 4.0, 4.0, 4.0, 3.0),
            new BBI_23_6_Student("Игумнов", 4.0, 5.0, 5.0, 3.0, 4.0, 5.0)
        };

        Group_Student[] groups = new Group_Student[bbi_23_4.Length + bbi_23_5.Length + bbi_23_6.Length];
        for (int i = 0; i < bbi_23_4.Length; i++)
        {
            groups[i] = bbi_23_4[i];
        }
        for (int i = 0; i < bbi_23_5.Length; i++)
        {
            groups[bbi_23_4.Length + i] = bbi_23_5[i];
        }
        for (int i = 0; i < bbi_23_6.Length; i++)
        {
            groups[bbi_23_4.Length + bbi_23_5.Length + i] = bbi_23_6[i];
        }

        Dictionary<string, double> averages = new Dictionary<string, double>();
        for (int i = 0; i < groups.GetLength(0); i++)
        {
            if (averages.ContainsKey(groups[i].group_name)) { }
            else
            {
                averages.Add(groups[i].group_name, groups[i].getAVG());
            }
        }

        var sortedAverages = averages.OrderByDescending(x => x.Value);

        Console.WriteLine("Group");
        foreach (var item in sortedAverages)
        {
            Console.WriteLine($"{item.Key}\t\t{item.Value:F2}");
        }
    }
}