using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class DinerController : Controller
    {
        private IRecipeService _recipeService;
        private IEventService _eventService;
        private IUserService _userService;

        public DinerController(IRecipeService recipeService, IEventService eventService, IUserService userService)
        {
            _recipeService = recipeService;
            _eventService = eventService;
            _userService = userService;
        }

        [Route("/diner/book")]
        public IActionResult Book()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            int dinerId = (int)HttpContext.Session.GetInt32("userId");

            if (dinerId == 0)
            {
                throw new ArgumentException("Id inválido");
            }

            var availableEvents = _eventService.GetAvailables();
            DinerBookViewModel model = new DinerBookViewModel
            {
                eventsList = availableEvents.Item1,
                availableDiners = availableEvents.Item2
            };

            return View(model);
        }
    }
}
