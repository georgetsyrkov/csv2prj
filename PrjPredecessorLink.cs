using System;
using System.Collections.Generic;

namespace csv2prj
{
    public class PredecessorLink
    {
        public int PredecessorUID {get;set;} = 0;
        public int Type {get;set;} = 1;
        public int CrossProject {get;set;} = 0;
        public int LinkLag {get;set;} = 0;
        public int LagFormat {get;set;} = 7;
    }
}