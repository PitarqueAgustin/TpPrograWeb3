using DAO.Entities;
using System.Collections.Generic;

namespace RecetasTP.Models
{
    public class ChefProfileViewModel
    {
        public User chef { get; set; }
        public List<Recipe> recipeList { get; set; }
        public int recipesCount { get; set; }
        public List<Event> eventsList { get; set; }
        public string[] eventTypesNames = { "", "Pendiente", "Finalizado", "Cancelado" };
    }
}
