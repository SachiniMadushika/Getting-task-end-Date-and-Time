using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskPlanner;

namespace TaskPlanner.test
{

    [TestClass]
    public class TestPlannerTests
    {
        TestPlannerTests test = new TestPlannerTests();

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
        public void TestMethod3()
        {



        }

        [TestMethod]
        public void TestMethod4()
        {
            var startedDay = new DateTime(2017, 12, 6, 8, 0, 0);
            var expectedTime = new TimeSpan(12, 0, 0);
            var FinishworkTimeDay = new DateTime(2017, 12, 6, 16, 0, 0);
            var actualEndDate = startedDay.Add(expectedTime);
            //var x = new DateTime();
            //if (actualEndDate.CompareTo(FinishworkTimeDay) > 0) {
            //     x= actualEndDate;
            //}
            //else
            //{
            //     x = actualEndDate.AddDays(1);
            //}

            //var expected = new DateTime(2017, 12, 7, 20, 0, 0);
            //Assert.AreEqual(expected, x);
        }

        //[TestMethod]
        //public void TestMethod4()
        //{
        //    var taskPlanner = new TaskPlanner();
        //    taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
        //    taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
        //    taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 24, 0, 0, 0));
        //    taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

        //    var start = new DateTime(2004, 5, 24, 18, 3, 0);
        //    double numberOfDays = -6.7470217d;

        //    var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
        //    var expected = new DateTime(2004, 5, 12, 10, 2, 0);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
