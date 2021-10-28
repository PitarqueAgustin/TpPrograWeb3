using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class RecipesType
    {
        public RecipesType()
        {
            Recipes = new HashSet<Recipe>();
        }

        public int RecipeTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
