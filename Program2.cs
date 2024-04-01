using System;

class Person
{
    private string family;
    public string Family { get { return family; } }


    public Person(string family1)
    {
        family = family1;

    }
}

class Student : Person
{
    private static int id;
    private int number;
    private double rez1, rez2, rez3, rez4;
    private double rez;
    private double sr(double x, double y, double z, double w)
    {
        return (x + y + z + w) / 4;
    }
    public double Rez { get { return rez; } }
    public Student(string family, double rezz1, double rezz2, double rezz3, double rezz4) : base(family)
    {
        rez = 0;
        rez1 = rezz1;
        rez2 = rezz2;
        rez3 = rezz3;
        rez4 = rezz4;
        rez = sr(rez1, rez2, rez3, rez4);
        number = Convert.ToInt32($"2305{id}");
        id++;
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Фамилия {0}\t Номер студ билета {1}\t Средний балл {2,4:f2}", Family, number, Rez);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] os = new Student[4];
        os[0] = new Student("Умкин", 3.0, 4.0, 5.0, 4.0);
        os[1] = new Student("Пупкин", 4.0, 5.0, 3.0, 5.0);
        os[2] = new Student("Лупкин", 3.0, 3.0, 4.0, 5.0);
        os[3] = new Student("Зупкин", 5.0, 5.0, 5.0, 5.0);

        foreach (var student in os)
        {
            student.DisplayInfo();
        }

        for (int i = 0; i < os.Length - 1; i++)
        {
            double amax = os[i].Rez;
            int imax = i;
            for (int j = i + 1; j < os.Length; j++)
            {
                if (os[j].Rez > amax)
                {
                    amax = os[j].Rez;
                    imax = j;
                }
            }
            Student temp;
            temp = os[imax];
            os[imax] = os[i];
            os[i] = temp;
        }

        Console.WriteLine();

        foreach (var student in os)
        {
            if (student.Rez >= 4)
            {
                student.DisplayInfo();
            }
        }
    }
}
