using DAO.Entities;
using System.Collections.Generic;

namespace RecetasTP.Models
{
    public class DefaultDetailsViewModel
    {
        public Event evnt { get; set; }
        public User evntChef { get; set; }
        public List<Rating> evntComments { get; set; }
    }
}
