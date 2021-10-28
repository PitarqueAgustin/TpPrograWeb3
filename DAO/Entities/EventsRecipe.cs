using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Entities
{
    public partial class EventsRecipe
    {
        public int EventRecipeId { get; set; }
        public int EventId { get; set; }
        public int RecipeId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
