﻿using DAO.Entities;
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
            _recipeService.Add(recipe);
            return Redirect("/");
        }

        [Route("chef/events")]
        public IActionResult Events()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
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
                return View("Events", e);
            }

            ModelState.AddModelError(string.Empty, "Error en el formulario.");
            return View("Events", e);
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

            return Redirect("/chef/profile");
        }

        [Route("chef/recipes/{id}/delete")]
        [HttpGet]
        public IActionResult DeleteRecipe(int id)
        {
            _recipeService.Remove(id);

            return Redirect("/chef/profile");
        }
    }
}
