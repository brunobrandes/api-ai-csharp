using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Parameters
{
    public class Date
    {
        public long Calendar { get; set; }
        public bool Exact { get; set; }
        public bool SpecifiedTimezone { get; set; }
        public bool Midnight { get; set; }
        public string RfcString { get; set; }
        public bool OnlyDate { get; set; }
        public bool DateTime { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int DayOfWeek { get; set; }
    }
}
