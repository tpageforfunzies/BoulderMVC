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
        public Guid UserId { get; set; }
        public string RouteName { get; set; }
        public string RouteNote { get; set; }
        public DateTime DateSent { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
