using DAO.Entities;
using DAO.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepo;

        public RecipeService(IRecipeRepository recipeRepo) 
        {
            _recipeRepo = recipeRepo;
        }

        public void Add(AddRecipeModel recipeModel)
        {
            Recipe recipe = new Recipe
            {
                ChefId = recipeModel.ChefId,
                Name = recipeModel.Name,
                CookingTime = recipeModel.CookingTime,
                Description = recipeModel.Description,
                Ingredients = recipeModel.Ingredients,
                RecipeTypeId = recipeModel.RecipeTypeId,
                RecipeType = _recipeRepo.TypeForId(recipeModel.RecipeTypeId),
                CreatedBy = recipeModel.ChefId.ToString(),
                CreatedDate = DateTime.Now,
                ModifiedBy = recipeModel.ChefId.ToString(),
                ModifiedDate = DateTime.Now
            };

            _recipeRepo.Add(recipe);
        }

        public void AddRecipeType(RecipesType newRecipeType)
        {
            _recipeRepo.AddRecipeType(newRecipeType);
        }

        public List<Recipe> GetListByUser(int chefId)
        {
            return _recipeRepo.GetListByUser(chefId);
        }

        public Recipe GetRecipeById(int id)
        {
            return _recipeRepo.GetRecipeForId(id);
        }

        public List<Recipe> GetRecipesFromEventId(int eventId)
        {
            return _recipeRepo.GetRecipesFromEventId(eventId);
        }

        public List<RecipesType> ListRecipeTypes()
        {
            return _recipeRepo.ListRecipeTypes();
        }

        public void Remove(int recipeId)
        {
            _recipeRepo.Remove(recipeId);
        }

        public void Update(Recipe recipe)
        {
            _recipeRepo.Update(recipe);
        }
    }
}
