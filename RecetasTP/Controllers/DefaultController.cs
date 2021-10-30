using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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
            
            
            List<string> imageList = new List<string>();
            imageList.Add("34737dc8-a861-40bf-8fbd-2d207ba34376.jpg");
            imageList.Add("71c79da2-1df7-4bfa-be55-3c72e5b8fa90.jpg");

            ViewBag.ImageList = imageList;
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
