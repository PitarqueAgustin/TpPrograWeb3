using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        public void Add(Recipe recipe);
        public RecipesType TypeForId(int recipeTypeId);
        public List<RecipesType> ListRecipeTypes();
        public List<Recipe> GetListByUser(int chefId);
        public Recipe GetRecipeForId(int id);
        public void Update(Recipe recipe);
        public void Remove(int recipeId);
        public List<Recipe> GetRecipesFromEventId(int eventId);
        void AddRecipeType(RecipesType newRecipeType);
    }
}
