using DAO.Entities;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private _20212C_TPContext _ctx;

        public RecipeRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Recipe recipe)
        {
            recipe.CreatedBy = recipe.ChefId.ToString();
            recipe.CreatedDate = DateTime.Now;

            _ctx.Recipes.Add(recipe);

            _ctx.SaveChanges();
        }

        public List<Recipe> GetListByUser(int chefId)
        {
            var list = _ctx.Recipes.Where(r => r.ChefId == chefId).Where(r => r.DeletedDate == null);
            return list.ToList();
        }

        public Recipe GetRecipeForId(int id)
        {
            return _ctx.Recipes.Find(id);
        }

        public List<Recipe> GetRecipesFromEventId(int eventId)
        {
            var query = from ev in _ctx.Events
                        join er in _ctx.EventsRecipes on ev.EventId equals er.EventId
                        join r  in _ctx.Recipes on er.RecipeId equals r.RecipeId
                        where er.EventId == eventId
                        select r;

            return query.ToList();
        }

        public List<RecipesType> ListRecipeTypes()
        {
            return _ctx.RecipesTypes.ToList();
        }

        public void Remove(int recipeId)
        {
            Recipe recipe = _ctx.Recipes.Find(recipeId);

            recipe.DeletedBy = recipe.ChefId.ToString();
            recipe.DeletedDate = DateTime.Now;
            recipe.ModifiedBy = recipe.ChefId.ToString();
            recipe.ModifiedDate = DateTime.Now;

            _ctx.Recipes.Update(recipe);

            _ctx.SaveChanges();
        }

        public RecipesType TypeForId(int recipeTypeId)
        {
            return _ctx.RecipesTypes.Find(recipeTypeId);
        }

        public void Update(Recipe recipe)
        {
            recipe.ModifiedBy = recipe.ChefId.ToString();
            recipe.ModifiedDate = DateTime.Now;

            _ctx.Recipes.Update(recipe);

            _ctx.SaveChanges();
        }
    }
}
