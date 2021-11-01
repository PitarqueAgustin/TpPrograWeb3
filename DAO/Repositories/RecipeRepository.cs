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
            _ctx.Recipes.Add(recipe);

            _ctx.SaveChanges();
        }

        public List<Recipe> GetListByUser(int chefId)
        {
            var list = _ctx.Recipes.Where(r => r.ChefId == chefId);
            return list.ToList();
        }

        public List<RecipesType> ListRecipeTypes()
        {
            return _ctx.RecipesTypes.ToList();
        }

        public RecipesType TypeForId(int recipeTypeId)
        {
            return _ctx.RecipesTypes.Find(recipeTypeId);
        }
    }
}
