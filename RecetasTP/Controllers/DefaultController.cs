using DAO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class DefaultController : Controller
    {
        private readonly ILogger<DefaultController> _logger;
        private IEventService _eventService;
        private IUserService _userService;

        public DefaultController(ILogger<DefaultController> logger, IEventService eventService, IUserService userService)
        {
            _logger = logger;
            _eventService = eventService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Default");
        }

        [Route("Default")]
        public IActionResult Default()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");

            List<Event> _eventList = _eventService.GetLastEventsEnded();
            DefaultViewModel defaultEventList = new DefaultViewModel
            {
                eventsList = _eventList,
                avgEventRatings = _eventService.GetAverageRating(_eventList)
            };

            return View(defaultEventList);
        }

        [HttpGet]
        [Route("Default/Details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");

            Event _evnt = _eventService.GetById(id);
            DefaultDetailsViewModel eventDetails = new DefaultDetailsViewModel
            {
                evnt = _evnt,
                evntChef = _userService.GetById(_evnt.ChefId),
                evntComments = _eventService.GetRatingForEventId(id)
            };

            return View(eventDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
