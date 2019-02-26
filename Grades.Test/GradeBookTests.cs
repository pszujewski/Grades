using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        GradeBook book = new GradeBook();

        public GradeBookTests()
        {
            book.AddGrade(10);
            book.AddGrade(90);
        }

        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(90, stats.maxGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(10, stats.minGrade);
        }

        [TestMethod]
        public void ComputesAverage()
        {
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(50, stats.avgGrade, 0.01);
        }

        [TestMethod]
        public void ComputesLetterGrade()
        {
            GradeStatistics stats = book.ComputeStatistics();
            Assert.IsTrue(stats.LetterGrade.Equals("F"));
        }
    }
}
