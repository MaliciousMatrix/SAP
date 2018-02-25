using NUnit.Framework;
using SAP.Common.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Test
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        [TestCaseSource(nameof(GetCreationTestCases))]
        public void TestCreation(Tuple<DayOfWeek, double> testCase)
        {
            Time time = new Time(testCase.Item1, testCase.Item2);
            Assert.AreEqual(testCase.Item1, time.Day);
            Assert.AreEqual(testCase.Item2, time.Hour);
        }

        [Test]
        [TestCaseSource(nameof(GetConversionTestCases))]
        public void TestConvertToString(Tuple<double, bool, string> testCase)
        {
            Time time = new Time(DayOfWeek.Monday, testCase.Item1);
            var stringTime = time.GetHourAsClockTime(testCase.Item2);

            Assert.AreEqual(testCase.Item3, stringTime);
        }

        [Test]
        public void TestEquivalance()
        {
            Time t1 = new Time(DayOfWeek.Monday, 12.25);
            Time t2 = new Time(DayOfWeek.Monday, 14.75);
            Time t3 = new Time(DayOfWeek.Tuesday, 12.25);
            Time t4 = new Time(DayOfWeek.Tuesday, 0.25);

#pragma warning disable CS1718 // Comparison made to same variable
            Assert.IsTrue(t1 == t1);
            Assert.IsTrue(t2 == t2);
            Assert.IsTrue(t3 == t3);
            Assert.IsTrue(t4 == t4);
            Assert.IsTrue(t1 >= t1);
            Assert.IsTrue(t2 <= t2);
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(t2 > t1);
            Assert.IsTrue(t2 >= t1);
            Assert.IsTrue(t3 > t1);
            Assert.IsTrue(t3 >= t1);
            Assert.IsTrue(t1 < t3);

            Assert.IsFalse(t1 > t2);
            Assert.IsFalse(t1 > t3);
            Assert.IsFalse(t3 < t1);
            Assert.IsFalse(t4 < t1);


        }

        private List<Tuple<double, bool, string>> GetConversionTestCases()
        {
            return new List<Tuple<double, bool, string>>()
            {
                new Tuple<double, bool, string>(6, false, "6:00 am"),
                new Tuple<double, bool, string>(6, true, "06:00"),
                new Tuple<double, bool, string>(8.25, false, "8:15 am"),
                new Tuple<double, bool, string>(8.25, true, "08:15"),
                new Tuple<double, bool, string>(0, true, "00:00"),
                new Tuple<double, bool, string>(0, false, "12:00 am"),
                new Tuple<double, bool, string>(0.75, true, "00:45"),
                new Tuple<double, bool, string>(0.75, false, "12:45 am"),
                new Tuple<double, bool, string>(12.5, false, "12:30 pm"),
                new Tuple<double, bool, string>(12.5, true, "12:30"),
                new Tuple<double, bool, string>(14.25, true, "14:15"),
                new Tuple<double, bool, string>(14.25, false, "2:15 pm"),
                new Tuple<double, bool, string>(23.75, true, "23:45"),
                new Tuple<double, bool, string>(23.75, false, "11:45 pm"),
            };
        }
        private List<Tuple<DayOfWeek, double>> GetCreationTestCases()
        {
            return new List<Tuple<DayOfWeek, double>>()
            {
                new Tuple<DayOfWeek, double>(DayOfWeek.Monday, 6.25),
                new Tuple<DayOfWeek, double>(DayOfWeek.Monday, 12.5),
                new Tuple<DayOfWeek, double>(DayOfWeek.Tuesday, 12),
                new Tuple<DayOfWeek, double>(DayOfWeek.Wednesday, 14.5),
                new Tuple<DayOfWeek, double>(DayOfWeek.Friday, 23),
                new Tuple<DayOfWeek, double>(DayOfWeek.Thursday, 0.25),
                new Tuple<DayOfWeek, double>(DayOfWeek.Friday, 8.75),
            };
        }
    }
}
