using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class Event
    {
        public Event()
        {
            Bookings = new HashSet<Booking>();
            EventsRecipes = new HashSet<EventsRecipe>();
            Ratings = new HashSet<Rating>();
        }

        public int EventId { get; set; }
        public int ChefId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DinersAmount { get; set; }
        public string Location { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public int State { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        public virtual User Chef { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<EventsRecipe> EventsRecipes { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
