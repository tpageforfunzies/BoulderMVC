using System;
using System.Collections.Generic;
using System.Text;

namespace Boulder.Models
{
    public class RouteDetail
    {
        public int RouteId { get; set; }
        public int RouteGrade { get; set; }
        public string RouteName { get; set; }
        public string RouteNote { get; set; }
        public DateTimeOffset DateSent { get; set; }
    }
}
