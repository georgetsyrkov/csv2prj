using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace csv2prj
{
    public class TimephasedData
    {
        public int UID { get; set; } = 0;
        public int Type { get; set; } = 0;
        public string Start { get; set; } = string.Empty;  //"2020-01-01T12:00:00";
        public string Finish { get; set; } = string.Empty; //"2020-01-01T15:00:00";
        public int Unit { get; set; } = 0;
        public string Value { get; set; } = string.Empty;

    }
}