using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace csv2prj
{
    public class Task
    {
        public int UID { get; set; } = 0;
        public int ID { get; set; } = 0;
        /// 0 - Fixed units; 1 - Fixed duration; 2 - Fixed work
        public int Type { get; set; } = 2;
        public int IsNull { get; set; } = 0;
        public int HideBar {get;set;} = 0;
        public int Summary { get; set; } = 0;
        public int IsSubproject { get; set; } = 0;
        public string WBS { get; set; } = "1";
        public int OutlineLevel { get; set; } = 1;
        public int ConstraintType { get;set;} = 1;
        public int EffortDriven {get;set;} = 0;
        public int Milestone { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int FixedCostAccrual { get; set; } = 3;
        public string Work { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int DurationFormat { get; set; } = 21;
        public string Start { get; set; } = string.Empty;  //"2020-01-01T12:00:00";
        public string Finish { get; set; } = string.Empty; //"2020-01-01T15:00:00";

        [XmlElement("PredecessorLink")]
        public List<PredecessorLink> PredecessorLinks { get; set; } = new List<PredecessorLink>();

    }
}