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
        private IEventService _eventService;

        public ChefController(IRecipeService recipeService, IEventService eventService)
        {
            _recipeService = recipeService;
            _eventService = eventService;
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

        [Route("chef/events")]
        public IActionResult Events()
        {
            return View();
        }

        [Route("chef/events")]
        [HttpPost]
        public IActionResult Events(AddEventModel e, IFormFile image)
        {
            if (ModelState.IsValid && image != null)
            {
                e.ChefId = (int)HttpContext.Session.GetInt32("userId");
                _eventService.Add(e, image);
                return View();
            }
            else if (image == null)
            {
                ModelState.AddModelError(string.Empty, "Por favor adjunte una imágen");
                return View("Index", e);
            }

            ModelState.AddModelError(string.Empty, "Error en el formulario.");
            return View("Index", e);
        }

        [Route("chef/cancel/{id}")]
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            int chefId = (int)HttpContext.Session.GetInt32("userId");

            if (id == 0)
            {
                throw new ArgumentException("Evento inválido");
            }

            _eventService.Delete(id, chefId);
            return View();
        }
    }
}
