using DAO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class ChefController : Controller
    {
        private IRecipeService _recipeService;
        private IEventService _eventService;
        private IUserService _userService;

        public ChefController(IRecipeService recipeService, IEventService eventService, IUserService userService)
        {
            _recipeService = recipeService;
            _eventService = eventService;
            _userService = userService;
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
            recipe.ChefId = (int)HttpContext.Session.GetInt32("userId");

            string newRecipeType = Request.Form["newRecipeType"];
            if (!string.IsNullOrEmpty(newRecipeType))
            {
                RecipesType addRecipeType = new RecipesType();
                addRecipeType.Name = newRecipeType;

                _recipeService.AddRecipeType(addRecipeType);

                recipe.RecipeTypeId = addRecipeType.RecipeTypeId;
            }

            _recipeService.Add(recipe);
            TempData["Message"] = "Receta agregada exitosamente.";
            TempData["AlertType"] = "alert-success";
            return RedirectToAction("Profile");
        }

        [Route("chef/events")]
        public IActionResult Events()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            int userId = (int) HttpContext.Session.GetInt32("userId");
            ViewBag.Recipes = _recipeService.GetListByUser(userId);
            ViewBag.Date = DateTime.Now.AddDays(1).ToString("yyyy-MM-ddTHH:mm");

            return View();
        }

        [Route("chef/events")]
        [HttpPost]
        public IActionResult Events(AddEventModel e, IFormFile image)
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.Recipes = _recipeService.GetListByUser(userId);
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            string[] recipes = HttpContext.Request.Form["recipes[]"];
            
            if (recipes.Length > 0)
            {
                if (ModelState.IsValid && image != null)
                {
                    e.ChefId = (int)HttpContext.Session.GetInt32("userId");
                    _eventService.Add(e, image, recipes);
                    TempData["Message"] = "Evento agregado exitosamente.";
                    TempData["AlertType"] = "alert-success";
                    return RedirectToAction("Profile");
                }
                else if (image == null)
                {
                    ModelState.AddModelError(string.Empty, "Por favor adjunte una imágen");
                    return View("Events", e);
                }

                ModelState.AddModelError(string.Empty, "Error en el formulario.");
                return View("Events", e);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "*Debe elegir al menos una receta");
                return View("Events", e);
            }

        }

        [Route("chef/cancel/{id}")]
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Evento inválido");
            }

            _eventService.Remove(id);
            TempData["Message"] = "Evento cancelado exitosamente.";
            TempData["AlertType"] = "alert-success";
            return RedirectToAction("Profile");
        }

        [Route("chef/profile")]
        [HttpGet]
        public IActionResult Profile()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.recipesTypes = _recipeService.ListRecipeTypes().ToArray();

            int chefId = (int)HttpContext.Session.GetInt32("userId");

            if (chefId == 0)
            {
                throw new ArgumentException("Id inválido");
            }


            List<Event> _eventsList = _eventService.GetListByUser(chefId);
            ChefProfileViewModel model = new ChefProfileViewModel
            {
                chef = _userService.GetById(chefId),
                recipeList = _recipeService.GetListByUser(chefId),
                recipesCount = _recipeService.GetListByUser(chefId).Count(),
                eventsList = _eventsList,
                reservedSpots = _eventService.GetReservedSpots(_eventsList)
            };

            return View(model);
        }

        [Route("chef/recipes/{id}/edit")]
        [HttpGet]
        public IActionResult EditRecipe(int id)
        {
            Recipe recipe = _recipeService.GetRecipeById(id);

            AddRecipeModel recipeModel = new AddRecipeModel()
            {
                RecipeId = recipe.RecipeId,
                ChefId = recipe.ChefId,
                Name = recipe.Name,
                CookingTime = recipe.CookingTime,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                RecipeTypeId = recipe.RecipeTypeId
            };

            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.RecipeTypes = _recipeService.ListRecipeTypes();

            return View(recipeModel);
        }

        [Route("chef/recipes/{id}/edit")]
        [HttpPost]
        public IActionResult EditRecipe(AddRecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                Recipe recipe = new Recipe()
                {
                    RecipeId = recipeModel.RecipeId,
                    ChefId = recipeModel.ChefId,
                    Name = recipeModel.Name,
                    CookingTime = recipeModel.CookingTime,
                    Description = recipeModel.Description,
                    Ingredients = recipeModel.Ingredients,
                    RecipeTypeId = recipeModel.RecipeTypeId
                };

                _recipeService.Update(recipe);
            }
            TempData["Message"] = "Receta modificada exitosamente.";
            TempData["AlertType"] = "alert-primary";
            return Redirect("/chef/profile");
        }

        [Route("chef/recipes/{id}/delete")]
        [HttpGet]
        public IActionResult DeleteRecipe(int id)
        {
            _recipeService.Remove(id);
            TempData["Message"] = "Receta borrada exitosamente.";
            TempData["AlertType"] = "alert-success";
            return Redirect("/chef/profile");
        }


        [Route("chef/events/{id}/edit")]
        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            TempData["Message"] = "";
            int userId = (int)HttpContext.Session.GetInt32("userId");
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.EventStates = _eventService.getStates();
            ViewBag.Recipes = _recipeService.GetListByUser(userId);

            Event ev = _eventService.GetById(id);
            ev.EventsRecipes = _eventService.GetEventsRecipes(ev.EventId);

            return View(ev);
        }

        [Route("chef/events/{id}/edit")]
        [HttpPost]
        public IActionResult EditEvent(Event ev, IFormFile image)
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.EventStates = _eventService.getStates();
            string[] recipes = HttpContext.Request.Form["recipes[]"];

            if (recipes.Length > 0)
            {
                if (ModelState.IsValid)
                {
                    Event modifiedEv = new Event()
                    {
                        EventId = ev.EventId,
                        ChefId = ev.ChefId,
                        Name = ev.Name,
                        Description = ev.Description,
                        Date = ev.Date,
                        DinersAmount = ev.DinersAmount,
                        Location = ev.Location,
                        Picture = ev.Picture,
                        Price = ev.Price,
                        State = ev.State
                    };

                    _eventService.Update(modifiedEv, image, recipes);
                }
                TempData["Message"] = "Evento modificado exitosamente.";
                TempData["AlertType"] = "alert-success";
                return Redirect("/chef/profile");
            }
            else 
            {
                int userId = (int)HttpContext.Session.GetInt32("userId");
                ViewBag.Recipes = _recipeService.GetListByUser(userId);
                TempData["Message"] = "*Debe elegir al menos una receta";
                return View(nameof(EditEvent),ev);
            }

        }

        [Route("chef/events/{id}/delete")]
        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            _eventService.Remove(id);
            TempData["Message"] = "Evento borrado exitosamente.";
            TempData["AlertType"] = "alert-success";
            return Redirect("/chef/profile");
        }
    }
}
