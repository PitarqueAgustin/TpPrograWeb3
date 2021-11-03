using DAO.Entities;
using System.Collections.Generic;

namespace RecetasTP.Models
{
    public class DefaultViewModel
    {
        public List<Event> eventsList { get; set; }
        public List<double> avgEventRatings { get; set; }
    }
}
