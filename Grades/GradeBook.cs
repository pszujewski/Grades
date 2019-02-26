using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        protected List<float> grades = new List<float>();
        private GradeStatistics stats;

        public GradeBook()
        {
            stats = new GradeStatistics();
        }

        // TextWriter is a useful abstraction in C# that allows you abstract away
        // the context in which you are "writing" a stream of data
        //
        public override void WriteGrades(TextWriter destination)
        {
            foreach (float grade in grades)
            {
                destination.WriteLine($"The current grade is {grade}");
            }
            destination.WriteLine("\n");
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            stats.SetStatistics(grades);
            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
    }
}
