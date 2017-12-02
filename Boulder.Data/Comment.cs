using System;
using System.Collections.Generic;
using System.Text;

namespace Boulder.Data
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Date { get; set; }
        public int RouteId { get; set; }
        public Guid UserId { get; set; }

        public virtual Route Route { get; set; }

    }
}
