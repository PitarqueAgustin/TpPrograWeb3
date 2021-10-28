using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class Booking
    {
        public int BookId { get; set; }
        public int EventId { get; set; }
        public int DinerId { get; set; }
        public int RecipeId { get; set; }
        public int DinersAmount { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual User Diner { get; set; }
        public virtual Event Event { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
