using System;
using System.IO;


/*
    Fields and properties for state
    Methods for behavior
    Events and delegates for notification and to propagate an event to many classes
*/

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            // Assign delegates that allow you to hook into the "event" of changing
            // book.Name
            //
            book.NameChanged += new NameChangedDelegate(onNameChanged);
            book.NameChanged += new NameChangedDelegate(onNameChangedFollowUp);

            GetBookName(book);
            AddGrades(book);
            SaveGradeToFileSystem(book);
           
            WriteGradesToScreen(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteGradesToScreen(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach(float grade in book)
            {
                Console.WriteLine();
            }

            Console.WriteLine($"{book.Name}\n");
            Console.WriteLine($"Max grade is {stats.maxGrade}\n");

            Console.WriteLine($"Min grade is {stats.minGrade}\n");
            Console.WriteLine($"Average grade is {stats.avgGrade}\n");
            Console.WriteLine($"Letter grade is {stats.LetterGrade}\n");
        }

        private static void SaveGradeToFileSystem(IGradeTracker book)
        {
            // Essentially wraps this code in a try, catch, finally chain to ensure
            // that it is dispoed of
            //
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(Console.Out);
                // outputFile.Close(); // since you are using "using" you don't need to explicitly close the stream
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);

            book.AddGrade(76);
            book.AddGrade(12);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Please enter a name for your grade book.");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex) // you can have multiple catch types but only one can run
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void onNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Name is being changed from {args.ExistingName} to {args.NewName}\n");
        }

        static void onNameChangedFollowUp(object sender, NameChangedEventArgs args)
        {
            string old = args.ExistingName;
            string next = args.NewName;
            Console.WriteLine($"Follow up: The old name is {old} and the new name is {next}\n");
        }
    }
}
