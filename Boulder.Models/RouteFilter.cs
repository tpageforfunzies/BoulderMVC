using System;
using System.Collections.Generic;
using System.Text;

namespace Boulder.Models
{
    public class RouteFilter
    {
        public int HighestGrade { get; set; }
        public int LowestGrade { get; set; }
        public int AverageGrade { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
