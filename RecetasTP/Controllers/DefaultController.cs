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

        public DefaultController(ILogger<DefaultController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
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
