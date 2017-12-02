using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boulder.Models
{
    public class RouteCreate
    {
        //the only three props the user will input
        //rest will be handled by service
        [Required]
        public string RouteName { get; set; }
        [Required]
        public int RouteGrade { get; set; }
        public string RouteNote { get; set; }
    }
}
