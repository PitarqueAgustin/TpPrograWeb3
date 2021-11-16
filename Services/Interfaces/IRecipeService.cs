using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRecipeService
    {
        public void Add(AddRecipeModel recipeModel);
        public List<RecipesType> ListRecipeTypes();
        public List<Recipe> GetListByUser(int chefId);
        public Recipe GetRecipeById(int recipeId);
        public void Update(Recipe recipe);
        public void Remove(int recipeId);
        public List<Recipe> GetRecipesFromEventId(int eventId);

    }
}
