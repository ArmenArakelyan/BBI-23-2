using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    { ////#1 
        using System;
        using System.Collections.Generic;
        using System.Linq;

class Program
    {
        static void Main(string[] args)
        {
            List<Run_500m> run500 = new List<Run_500m>();

            run500.Add(new Run_500m("Иванова", "Группа 1", "Тренер Ларкова", 120));
            run500.Add(new Run_500m("Петрова", "Группа 2", "Тренер Паркова", 110));
            run500.Add(new Run_500m("Сидорова", "Группа 1", "Тренер Жаркова", 100));
            run500.Add(new Run_500m("Смирнова", "Группа 3", "Тренер Маркова", 90));

            Console.WriteLine("Результаты кросса на 500м:");
            Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

            foreach (var runner in run500.OrderBy(runner => runner.Result))
            {
                runner.DisplayInfo();
            }

            int passedNorm = run500.Count(runner => runner.Result <= 100);
            Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");

            List<Run_100m> run100 = new List<Run_100m>();

            run100.Add(new Run_100m("Иванова", "Группа 1", "Тренер Ларкова", 11));
            run100.Add(new Run_100m("Петрова", "Группа 2", "Тренер Паркова", 7));
            run100.Add(new Run_100m("Сидорова", "Группа 1", "Тренер Жаркова", 13));
            run100.Add(new Run_100m("Смирнова", "Группа 3", "Тренер Маркова", 8));

            Console.WriteLine("Результаты кросса на 100м:");
            Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

            foreach (var runner in run100.OrderBy(runner => runner.Result))
            {
                runner.DisplayInfo();
            }

            passedNorm = run100.Count(runner => runner.Result <= 100);
            Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");
        }
    }

    abstract class Runner
    {
        public string Surname { get; private set; }
        public string Group { get; private set; }
        public string TeacherSurname { get; private set; }
        public double Result { get; private set; }

        public Runner(string surname, string group, string teacherSurname, double result)
        {
            Surname = surname;
            Group = group;
            TeacherSurname = teacherSurname;
            Result = result;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result}");
        }
    }

    class Run_500m : Runner
    {
        public Run_500m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
        {

        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 100 ? "Выполнен" : "Не выполнен")}");
        }
    }

    class Run_100m : Runner
    {
        public Run_100m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
        {

        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 10 ? "Выполнен" : "Не выполнен")}");
        }
    }

    List<Run_500m> run500 = new List<Run_500m>();

    run500.Add(new Run_500m("Иванова", "Группа 1", "Тренер Ларкова", 120)); 
        run500.Add(new Run_500m("Петрова", "Группа 2", "Тренер Паркова", 110)); 
        run500.Add(new Run_500m("Сидорова", "Группа 1", "Тренер Жаркова", 100)); 
        run500.Add(new Run_500m("Смирнова", "Группа 3", "Тренер Маркова", 90)); 

        Console.WriteLine("Результаты кросса на 500м:"); 
        Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив"); 

        foreach (var runner in run500.OrderBy(runner => runner.Result)) 
        { 
            runner.DisplayInfo(); 
        }

int passedNorm = run500.Count(runner => runner.Result <= 100);
Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}");

List<Run_100m> run100 = new List<Run_100m>();

run100.Add(new Run_100m("Иванова", "Группа 1", "Тренер Ларкова", 11));
run100.Add(new Run_100m("Петрова", "Группа 2", "Тренер Паркова", 7));
run100.Add(new Run_100m("Сидорова", "Группа 1", "Тренер Жаркова", 13));
run100.Add(new Run_100m("Смирнова", "Группа 3", "Тренер Маркова", 8));

Console.WriteLine("Результаты кросса на 100м:");
Console.WriteLine("Фамилия\t\t Группа \t\t Преподаватель \t\t Результат в секундах \t\t Норматив");

foreach (var runner in run100.OrderBy(runner => runner.Result))
{
    runner.DisplayInfo();
}

passedNorm = run100.Count(runner => runner.Result <= 100);
Console.WriteLine($"\nОбщее количество участниц, выполнивших норматив: {passedNorm}"); 
    } 
} 

abstract class Runner
{
    public string Surname { get; private set; }
    public string Group { get; private set; }
    public string TeacherSurname { get; private set; }
    public double Result { get; private set; }

    public Runner(string surname, string group, string teacherSurname, double result)
    {
        Surname = surname;
        Group = group;
        TeacherSurname = teacherSurname;
        Result = result;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result}");
    }
}

class Run_500m : Runner
{
    public Run_500m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
    {

    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 100 ? "Выполнен" : "Не выполнен")}");
    }
}

class Run_100m : Runner
{
    public Run_100m(string Surname, string Group, string TeacherSurname, double Result) : base(Surname, Group, TeacherSurname, Result)
    {

    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"{Surname}\t\t{Group}\t\t{TeacherSurname}\t\t{Result:F2}\t\t{(Result <= 10 ? "Выполнен" : "Не выполнен")}");
    }
}
