using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class Recipe
    {
        public Recipe()
        {
            Bookings = new HashSet<Booking>();
            EventsRecipes = new HashSet<EventsRecipe>();
        }

        public int RecipeId { get; set; }
        public int ChefId { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int RecipeTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        public virtual RecipesType RecipeType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<EventsRecipe> EventsRecipes { get; set; }
    }
}
