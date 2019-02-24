using System;
using System.Collections.Generic;
using System.Drawing;

namespace SignalRTest.Models
{
    public class Call
    {
        public int ID { get; set; }
        public string UID { get; set; }
        public string CallFile { get; set; }
        public string SubjectTo { get; set; }
        public string SubjectFrom { get; set; }
        public int? ActionType { get; set; }
        public IEnumerable<Company> Companies { get; set; } 

    }
}