using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace csv2prj
{
    public class Assignment
    {
        public int UID { get; set; } = -65535;
        public int TaskUID { get; set; } = -65535;
        public int ResourceUID { get; set; } = -65535;

        public int Milestone { get; set; } = 0;

        public string Work {get;set;} = "PT0H0M0S";


        [XmlElement("TimephasedData")]
        public List<TimephasedData> TimephasedDatas {get;set;} =  new List<TimephasedData>();

    }
}