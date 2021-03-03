using System;
using System.Collections.Generic;

namespace csv2prj
{
    public class WeekDay
    {
        public int DayType { get; set; } = 1;
        public int DayWorking { get; set; } = 0;

        public List<WorkingTime> WorkingTimes { get; set; } =
            new List<WorkingTime>()
            {
                new WorkingTime() { FromTime = "09:00:00", ToTime = "13:00:00"},
                new WorkingTime() { FromTime = "14:00:00", ToTime = "18:00:00"}
            };

    }
}