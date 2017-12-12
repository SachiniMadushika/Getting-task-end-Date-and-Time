using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskPlanner;

namespace TaskPlanner.test
{
    [TestClass]
    public class TestPlannerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var StartworkTimeDay = new TimeSpan(8, 0, 0);
            var FinishworkTimeDay = new TimeSpan(16, 0, 0);
            TimeSpan WorkingHours = FinishworkTimeDay.Subtract(StartworkTimeDay);
            TimeSpan actual = new TimeSpan(8, 0, 0);
            Assert.AreEqual(WorkingHours, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var startedDay = new DateTime(2017, 12, 6, 8, 0, 0);
            var expectedTime = new TimeSpan(2, 0, 0);
            var actualEndDate = startedDay.Add(expectedTime);
            var endDate = new DateTime(2017, 12, 6, 10, 0, 0);
            Assert.AreEqual(actualEndDate, endDate);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var startedDay = new DateTime(2017, 12, 6, 8, 0, 0);
            var expectedTime = new TimeSpan(12, 0, 0);
            var FinishworkTimeDay = new DateTime(2017, 12, 6, 20, 0, 0);
            var actualEndDate = startedDay.Add(expectedTime);
        }
        [TestMethod]
        public void OnNormalDay_PlusDaysAndHours_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2017, 12, 4, 15, 0, 0);
            double days = 0.5;

            DateTime expected = new DateTime(2017, 12, 4, 12, 00, 00);
            DateTime result=taskPlanner.GetFinishingDate(date,days);

            Assert.AreEqual(expected,result);
        }
        [TestMethod]
        public void OnNormalDay_PlusOneDay_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2017, 12, 4, 8, 0, 0);
            double days = 1.0;

            DateTime expected = new DateTime(2017, 12, 4, 16, 0, 0);
            DateTime result = taskPlanner.GetFinishingDate(date, days);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OnNormalDay_PlusOneDayAndHours_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2017, 12, 4, 8, 0, 0);
            double days = 1.5;

            DateTime expected = new DateTime(2017, 12, 5, 12, 0, 0);
            DateTime result = taskPlanner.GetFinishingDate(date, days);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OnNormalDay_PlusOneDayAndHoursWithWeekend_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2017, 12, 8, 11, 0, 0);
            double days = 1.5;

            DateTime expected = new DateTime(2017, 12, 5, 12, 0, 0);
            DateTime result = taskPlanner.GetFinishingDate(date, days);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OnNormalDay_PlusAssignmentTest1_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2017, 12, 4, 15, 7, 0);
            double days = 0.25;

            DateTime expected = new DateTime(2017, 12, 5, 9, 7, 0);
            DateTime result = taskPlanner.GetFinishingDate(date, days);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OnNormalDay_PlusAssignmentTest4_EndDate()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            DateTime date = new DateTime(2004, 5, 24, 8, 3, 0);
            double days = 12.782709;

            DateTime expected = new DateTime(2017, 6, 10, 14, 18, 0);
            DateTime result = taskPlanner.GetFinishingDate(date, days);

            Assert.AreEqual(expected, result);
        }
    }
}
