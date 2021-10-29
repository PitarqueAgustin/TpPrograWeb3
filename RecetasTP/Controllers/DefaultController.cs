using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System;
using System.Diagnostics;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class DefaultController : Controller
    {
        private readonly ILogger<DefaultController> _logger;
        
        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("default");
        }

        [Route("default")]
        public IActionResult Default()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            return View();
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
