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
    }
}
