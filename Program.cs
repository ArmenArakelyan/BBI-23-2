
using System;
using System.Linq;

namespace Level2
{
    internal class Program
    {
        abstract class Student
        {
            protected string _surname;
            protected string _name;
            protected double[] _exams;
            protected bool _passed;

            public bool Passed { get { return _passed; } }

            public Student(string surname, string name, params double[] exams)
            {
                _surname = surname;
                _name = name;
                _exams = exams;
                _passed = exams.All(exam => exam != 2);
            }

            public double Avg()
            {
                return _exams.Average();
            }

            public void Display()
            {
                Console.WriteLine($"{_surname} {_name}, средний балл: {Avg()}");
            }

            public abstract void CheckStatus();
        }

        class ForeignStudent : Student
        {
            private int _visaDuration;

            public int VisaDuration
            {
                get { return _visaDuration; }
                private set { _visaDuration = value; }
            }

            public ForeignStudent(string surname, string name, int visaDuration, params double[] exams)
                : base(surname, name, exams)
            {
                VisaDuration = visaDuration;
            }

            public override void CheckStatus()
            {
                if (VisaDuration <= 0)
                {
                    Console.WriteLine($"{Passed} {_surname} {_name}, ваша виза истекла. Необходимо обновить визу.");
                }
            }

            public void SubtractDaysFromVisa(int days)
            {
                VisaDuration -= days;
            }
        }

        static void Main(string[] args)
        {


            ForeignStudent[] foreignStudents = new ForeignStudent[2]
            {
                new ForeignStudent("Kintina", "Darya", 180, 4, 2, 5),
                new ForeignStudent("Chernogus", "Maria", 90, 4, 3, 5)
            };

            foreach (var foreignStudent in foreignStudents)
            {
                for (int i = 0; i < 100; i++)
                {
                    foreignStudent.SubtractDaysFromVisa(1);
                    foreignStudent.CheckStatus();
                }
            }


        }

        static void Sort(Student[] students)
        {
            for (int i = 1; i < students.Length; i++)
            {
                for (int j = 1; j < students.Length; j++)
                {
                    if (students[j].Avg() > students[j - 1].Avg())
                    {
                        Student temp = students[j];
                        students[j] = students[j - 1];
                        students[j - 1] = temp;
                    }
                }
            }
        }
    }
}