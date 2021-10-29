using DAO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetasTP.Filters;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class ChefController : Controller
    {
        private IRecipeService _recipeService;

        public ChefController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Route("/chef/recipes")]
        public IActionResult Recipes()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.RecipeTypes = _recipeService.ListRecipeTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Recipe(AddRecipeModel recipe) 
        {
            recipe.ChefId = (int) HttpContext.Session.GetInt32("userId");
            _recipeService.Add(recipe);
            return Redirect("/");
        }
    }
}
