using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        //private GradeBook book1 = new GradeBook();
        //private GradeBook book2 = new GradeBook();

        [TestMethod]
        public void IntVariableHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreEqual(100, x2);
        }

        [TestMethod]
        public void StringComparison()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = string.Equals(name1, name2, System.StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2019, 1, 1);
            // date is immutable
            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void StringIsReferenceTypeButBehavesLikeValueType()
        {
            string name = "peter";
            string name2 = name;

            name = name.ToUpper();
            bool result = string.Equals(name, "PETER");

            bool result2 = string.Equals(name2, "peter");
            Assert.IsTrue(result && result2);
        }

        [TestMethod]
        public void UsingArrayOfFloats()
        {
            float[] grades;
            grades = new float[3]; // Array size is fixed

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UsingArrayOfStrings()
        {
            string[] names;
            names = new string[4];

            names.SetValue("Peter", 0);
            names.SetValue("John", 1);

            names.SetValue("Chelsea", 2);
            names.SetValue("Skipper", 3);

            double avgCt = getAverageNumberOfChars(names);
            Assert.AreEqual(avgCt, 5.75d);

            string name = (string) names.GetValue(3);
            bool isSkipper = name.Equals("Skipper");
        }

        private double getAverageNumberOfChars(string[] names)
        {
            int sum = 0;

            foreach (string name in names)
            {
                sum += name.Length;
            }

            return (double) sum / names.Length;
        }

        public delegate string Writer(string message);

        public class Logger
        {
            public string WriteAndReturnMessage(string message)
            {
                Console.WriteLine(message);
                return message;
            }
        }


        [TestMethod]
        public void UsingDelegates()
        {
            Logger logger = new Logger();
            Writer writer = new Writer(logger.WriteAndReturnMessage);

            string message = writer("Hello Csharp");
            Assert.AreEqual("Hello Csharp", message);
        }
    }
}
