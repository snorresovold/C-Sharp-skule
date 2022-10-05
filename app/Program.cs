﻿using System;
using System.IO;
using System.Text.Json;
namespace MyApplication
{
    // elev klasse som holder på verdier
    public class Student
    {

        public string name { get; set; }

        public double grades { get; set; }

        public int absence { get; set; }


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
        static Student add_student()
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
            Student new_student = new Student(name, grades, absence);
            return new_student;
        }
        static void Main(string[] args)
        {
            // tomt array som skal holde alle elevene
            //Student[] students = new Student[] { };
            // bestemte meg for å bruke ei liste istedet for et array
            List<Student> students = new List<Student>();
            double input;
            // før programmet "starter" så lagrer eg alle elever som allerede fins til prosjektet
            string json_string = File.ReadAllText("students.json");
            Console.WriteLine(json_string);
            Student sus = JsonSerializer.Deserialize<Student>(json_string);
            Console.WriteLine(sus);

            // infinite loop som programmet kjøres i ganske standard for konsoll applikasjoner
            while (true)
            {
                // bare basic consol commands
                Console.WriteLine("Hello, welcome to Snorre's Student Administrative system");
                Console.WriteLine("CTRL + C to exit");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Get all students");
                Console.WriteLine("2: add a new student");
                Console.WriteLine("3: Save to a json file");
                input = Convert.ToDouble(Console.ReadLine());

                if (input == 1)
                {
                    foreach (Student student in students)
                    {
                        Console.WriteLine("NAME: " + student.name);
                        Console.WriteLine("GRADES: " + student.grades);
                        Console.WriteLine("ABSENCE: " + student.absence);
                    }
                }
                else if (input == 2)
                {
                    // lag ny elev med methoden eg har lagt og append eleven til listen
                    Student new_student = add_student();
                    students.Add(new_student);
                    //Console.WriteLine(students);
                }
                else if (input == 3)
                {
                    // for kvar elev i "students" så serialiser dataen (gjer den om til bytes) og skriv den til students.json
                    foreach (Student student in students)
                    {
                        string jsonString = JsonSerializer.Serialize(student);

                        //Console.WriteLine(jsonString);
                        File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "students.json"), jsonString);
                    }
                }
                else
                {
                    // hvis du skriver noko annerledes enn 1 eller 2 så får du denne meldingen
                    Console.WriteLine("this was not a valid input");
                }
            }
        }
    }
}