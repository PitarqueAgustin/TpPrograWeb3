using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int EventId { get; set; }
        public int DinerId { get; set; }
        public int Rating1 { get; set; }
        public string Comments { get; set; }

        public virtual User Diner { get; set; }
        public virtual Event Event { get; set; }
    }
}
