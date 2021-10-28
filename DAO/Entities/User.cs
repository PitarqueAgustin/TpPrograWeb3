using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Events = new HashSet<Event>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
