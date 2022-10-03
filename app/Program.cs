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
            // tomt array som skal holde alle elevene
            Student[] students = new Student[] { };
            string input;
            // infinite loop som programmet kjøres i ganske standard for konsoll applikasjoner
            while (true)
            {
                // bare basic consol commands
                Console.WriteLine("Hello, welcome to Snorre's Student Administrative system");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Get all students");
                Console.WriteLine("2: add a new student");
                input = Console.ReadLine();

            }
        }
        // funksjon som har all konsoll logikken

        static void get_students()
        {

        }
        static void add_student()
        {
            //initialiserer variablene så eg kan gi de verdier seinere
            string name;
            double grades;
            int absence;
            // viser tekst og lagrer elevens navn
            Console.WriteLine("What is the students name?");
            name = Console.ReadLine();

            // viser tekst i konsollen og konverterer til double, vil få error hvis input ikkje er numerisk
            Console.WriteLine("What is the students grades? (has to be numbers)");
            grades = Convert.ToDouble(Console.ReadLine());

            // viser tekst og gjer det samme som koden over men med Ints, ikkje doubles
            Console.WriteLine("how many minutes has the student been absent? (has to be numbers)");
            absence = Int32.Parse(Console.ReadLine());
            return name, grades, absence
        }
    }
}