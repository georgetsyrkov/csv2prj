using System;
using System.Collections.Generic;

namespace csv2prj
{
    public class Calendar
    {
        public int UID { get; set; } = 1;
        public string Name { get; set; } = "Стндртный";
        public int IsBaseCalendar { get; set; } = 1;

        public int BaseCalendarUID { get; set; } = -1;

        public List<WeekDay> WeekDays { get; set; } = new List<WeekDay>()
        {
            new WeekDay() {DayType = 1},
            new WeekDay() {DayType = 2, DayWorking = 1},
            new WeekDay() {DayType = 3, DayWorking = 1},
            new WeekDay() {DayType = 4, DayWorking = 1},
            new WeekDay() {DayType = 5, DayWorking = 1},
            new WeekDay() {DayType = 6, DayWorking = 1},
            new WeekDay() {DayType = 7}
        };

    }
}