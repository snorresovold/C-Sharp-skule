using System;
using System.IO;
using Newtonsoft.Json;
// basic elev admin konsoll prosjekt, koden er skrevet på engelsk, eg pleier p kommentere på englesk også men siden eg blir vurdert på de så er kommenterene på norsk
// Link til prosjektet på Github: https://github.com/snorresovold/C-Sharp-skule

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

            // leser students.json filå
            string json_string = File.ReadAllText("students.json");

            //Console.WriteLine(json_string);
            // try catch for eg har hatt erfaring med json deserialisering i golang å python, det er spesielt lurt å ha json logikk i try catch
            // btw deserialisering er basically det motsatte en serialisering, altså det gjer bytes til objekter
            try
            {
                // tar json stringen og deserialiserer den til ei liste med elever
                List<Student> stored_students = JsonConvert.DeserializeObject<List<Student>>(json_string);

                //Console.WriteLine(stored_students);

                // legger de gamle elevene i hoved elev listen
                students.AddRange(stored_students);
            }
            catch
            {
                // hvis det kommer ein error så kan programmet fortsatt kjøre og brukeren får beskjed
                Console.WriteLine("got an error retrieving students");
            }

            // infinite loop som programmet kjøres i ganske standard for konsoll applikasjoner
            while (true)
            {
                // bare basic consol commands
                Console.WriteLine("Hello, welcome to Snorre's Student Administrative system");
                Console.WriteLine("CTRL + C to exit");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Get all students");
                Console.WriteLine("2: add a new student");
                Console.WriteLine("3: delete a student");
                Console.WriteLine("4: Save to a json file");
                // input er det som bruker skriver til konsollen
                input = Convert.ToDouble(Console.ReadLine());

                if (input == 1)
                {
                    // for kvar elev, skriv til konsollen verdiene deires
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
                    Console.WriteLine("Who do you want to remove? Make sure to write their name correctly");
                    string to_delete = Console.ReadLine();
                    // har faktisk 0 peiling koffor men du trenger .ToList eller så får du ein error
                    foreach (Student student in students.ToList())
                    {
                        // hvis det er fleire elever med samme navn så kommer begge til å bli sletta, ser denna nå men drite litt i an akkuartt nå, får fiksa seinare
                        // har også ToLower for å fikse hvis brukeren skriver det litt feil
                        if (student.name.ToLower() == to_delete.ToLower())
                        {
                            // logger at ein bruker skal bli slettet så fjernes den fra students listå
                            Console.WriteLine($"deleting {student.name}");
                            students.Remove(student);
                        }
                        else
                        {
                            Console.WriteLine("There is no students with that name, are you sure you wrote it correctly?");
                        }
                    }
                }
                else if (input == 4)
                {
                    // konverter students listå til ein json string med indented (vet ikkje ordet på norsk) formatering
                    string json = JsonConvert.SerializeObject(students, Formatting.Indented);

                    // skriv json stringen til students.json
                    // bruker også Directory.GetCurrentDirectory() for å finne kvor programmet er i filsystemet
                    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "students.json"), json);
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