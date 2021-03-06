﻿using System;
using System.Collections.Generic;

namespace TaskPlanner
{
    public class TaskPlanner
    {
        TimeSpan StartworkTimeDay = new TimeSpan(8, 0, 0);
        TimeSpan FinishworkTimeDay = new TimeSpan(16, 0, 0);
        decimal NoOfDays = 2.5M;
        DateTime WorkdayStartTime;


        private readonly HashSet<DateTime> Holidays = new HashSet<DateTime>();

        private bool IsHoliday(DateTime date)
        {
            Holidays.Add(new DateTime(2004, 5, 17));
            Holidays.Add(new DateTime(2004, 5, 24));
            Holidays.Add(new DateTime(2004, 5, 27));
            return Holidays.Contains(date);
        }
        private bool IsWeekEnd(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        private DateTime GetNextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            }
            while (IsHoliday(date) || IsWeekEnd(date));
            return date;
        }

        private int ConvertNegativeToDays(double NoOfDays)
        {
            double days = Math.Ceiling(NoOfDays);
            int NegativeDays = (int)Math.Ceiling(days);
            return NegativeDays;
        }
        private TimeSpan ConvertNegativeTime(double NoOfDays)
        {
            double days = Math.Floor(Math.Abs(NoOfDays));
            double hours = (NoOfDays - days) * 8;
            double minutes = (hours - Math.Floor(hours)) * 60;
            double seconds = (minutes - Math.Floor(minutes)) * 60;
            int H = (int)Math.Floor(hours);
            int M = (int)Math.Floor(minutes);
            int S = (int)Math.Floor(seconds);
            TimeSpan timeFormat = new TimeSpan(H, M, S);
            return timeFormat;
        }

        public int ConvertPositiveToDays(double NoOfDays)
        {
            double days = Math.Floor(NoOfDays);
            int PositiveDays = (int)Math.Floor(days);
            return PositiveDays;
        }
        public TimeSpan ConvertPositiveToTime(double NoOfDays)
        {
            double days = Math.Floor(NoOfDays);
            double hours = (NoOfDays - days) * 8;
            double minutes = (hours - Math.Floor(hours)) * 60;
            double seconds = (minutes - Math.Floor(minutes)) * 60;
            int H = (int)Math.Floor(hours);
            int M = (int)Math.Floor(minutes);
            int S = (int)Math.Floor(seconds);
            //string timeFormat = String.Format("{0:00},{1:00}:{2:00}", D, H, M);

            TimeSpan timeFormat = new TimeSpan(H, M, S);
            return timeFormat;
        }
        public DateTime GetFinishingDate(DateTime WorkdayStartTime, double NoOfDays)
        {
            DateTime GetFinishingDate;
            if (NoOfDays > 0)
            {
                DateTime EndDate = WorkdayStartTime.AddDays(ConvertPositiveToDays(NoOfDays));
                GetFinishingDate = EndDate.Add(ConvertPositiveToTime(NoOfDays));
              
            }
            else
            {
                DateTime EndDate = WorkdayStartTime.AddDays(-1 * ConvertNegativeToDays(NoOfDays));
                GetFinishingDate = EndDate.Subtract(ConvertNegativeTime(NoOfDays));
            }
            return GetNextWorkingDay(GetFinishingDate);
        }















        //public DateTime MoveTaskToDay(DateTime endDate, DateTime WorkdayStartTime)
        //{
        //    if(endDate.TimeOfDay >= FinishworkTimeDay)
        //    {
        //        TimeSpan remainingHours = endDate.TimeOfDay - FinishworkTimeDay;
        //       return WorkdayStartTime.AddDays(1).Add(remainingHours);

        //    }
        //    else
        //    {
        //        remainingHours = endDate.TimeOfDay;
        //        var endTimeInDay = StartworkTimeDay.Add(remainingHours);
        //    }
            
        //}

        //static void Main(string[] args)
        //{
        //    Holidays.Add(new DateTime(2004, 5, 17));
        //    Holidays.Add(new DateTime(2004, 5, 24));
        //    Holidays.Add(new DateTime(2004, 5, 27));

        //    //Holidays.Add(new DateTime(DateTime.Now.Year, 1, 5));

        //    DateTime WorkdayStartTime = new DateTime(2017, 12, 11, 16, 0, 0);
        //    Console.Write(WorkdayStartTime);
        //    Console.WriteLine(" {0:dddd}", WorkdayStartTime);

        //    decimal NoOfDays = 0.5M;
        //    var x = ConvertFromDecimalToDDHHMM(NoOfDays);
        //    var y = ConvertFromDecimalToDays(NoOfDays);


        //    Console.WriteLine(y);
        //    Console.WriteLine(x);

        //    System.DateTime endDate1 = WorkdayStartTime.AddDays(ConvertFromDecimalToDays(NoOfDays));
        //    System.DateTime endDate = endDate1.Add(ConvertFromDecimalToDDHHMM(NoOfDays));
            

        //    Console.WriteLine(endDate);

        //    //var currentDate = GetNextWorkingDay(endDate);
        //    //Console.Write(currentDate);
        //    //Console.WriteLine(" {0:dddd}", currentDate);


        
    }
}
