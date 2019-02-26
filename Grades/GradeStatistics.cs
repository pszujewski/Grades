using System;
using System.Collections.Generic;

namespace Grades
{
    public class GradeStatistics
    {
        public float maxGrade;
        public float minGrade;
        public float avgGrade;

        public GradeStatistics()
        {
            maxGrade = float.MinValue;
            minGrade = float.MaxValue;
            avgGrade = 0;
        }

        public string LetterGrade
        {
            get
            {
                string result = "F";

                if (avgGrade >= 90)
                {
                    result = "A";
                }
                else if (avgGrade >= 80)
                {
                    result = "B";
                }
                else if (avgGrade >= 70)
                {
                    result = "C";
                }
                else if (avgGrade  >= 60)
                {
                    result = "D";
                }

                return result;
            }
        }

        public void SetStatistics(List<float> grades)
        {
            float sum = 0;

            foreach(float grade in grades)
            {
                sum += grade;
                minGrade = Math.Min(minGrade, grade);
                maxGrade = Math.Max(maxGrade, grade);
            }

            avgGrade = sum / grades.Count;
        }
    }
}
