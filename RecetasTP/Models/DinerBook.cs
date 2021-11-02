using DAO.Entities;
using System.Collections.Generic;

namespace RecetasTP.Models
{
    public class DinerBookViewModel
    {
        public List<Event> eventsList { get; set; }
        public List<Recipe> recipeList { get; set; }
        public List<int> availableDiners { get; set; }
    }
}
