using System;
using System.Collections.Generic;

namespace csv2prj
{
    public class Project
    {
        public string Name { get; set; } = "Проектище";
        public string Author { get; set; } = "Дядя Вася";

        public int SaveVersion { get; set; } = 11;

        public int ProjectExternallyEdited { get; set; } = 0;

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastSaved { get; set; } = DateTime.Now;

        public DateTime StartDate { get; set; } = new DateTime(2020, 1, 1, 8, 0, 0);

        public DateTime FinishDate { get; set; } = new DateTime(2020, 1, 3, 8, 0, 0);

        public DateTime CurrentDate { get; set; } = new DateTime(2019, 12, 31, 8, 0, 0);
        
        public int CalendarUID { get; set; } = 1;

        public int ScheduleFromStart { get; set; } = 0;

        public int HonorConstraints { get; set; } = 0;

        public int WorkFormat { get; set; } = 5;
        public int DurationFormat { get; set; } = 5;

        public List<Calendar> Calendars { get; set; } = new List<Calendar>();

        public List<Task> Tasks { get; set; } = new List<Task>();

        public List<Resource> Resources { get; set; } = new List<Resource>();

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();


    }
}