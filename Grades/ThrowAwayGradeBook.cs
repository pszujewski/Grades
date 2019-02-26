using System;
namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        // There is 
        public override GradeStatistics ComputeStatistics()
        {
            float lowest = float.MaxValue;

            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);
            return base.ComputeStatistics(); // base is the "base" class this one inherits from
        }
    }
}
