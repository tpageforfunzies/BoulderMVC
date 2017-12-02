using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Boulder.Data
{
    public class Route
    {
        public int RouteId { get; set; }
        public int RouteGrade { get; set; }
        public string RouteName { get; set; }
        public string RouteNote { get; set; }
        public DateTimeOffset DateSent { get; set; }

        public virtual Guid UserId {get; set;}

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
