using System;

namespace MyApplication
{
    // elev klasse som holder på verdier
    class Student
    {
        public string name;
        public double grades;
        public int absence;

        // gjer at verdiene er argumenter som må skrives in manuelt

        public Student(string studentName, double studentGrades, int StudentAbsence)
        {
            name = studentName;
            grades = studentGrades;
            absence = StudentAbsence;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Array som skal holde alle elever
            Student[] students = new Student[] { };

            //Lager en ny elev og legger de i et array
            Student Snorre = new Student("Snorre", 4.75, 23);
            students.Append(Snorre);
            Console.WriteLine(students);
            // kjører IO funksjonen
            IO();
        }
        // funksjon som har all konsoll logikken
        static void IO()
        {
            string input;
            // infinite loop som programmet kjøres i
            while (true)
            {
                Console.WriteLine("Hello, welcome to Snorre's Student Administrative system");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Get all students");
                Console.WriteLine("2: add a new student");
                input = Console.ReadLine();
            }
        }
        static void get_students()
        {

        }
        static void add_student()
        {
            
        }
    }
}