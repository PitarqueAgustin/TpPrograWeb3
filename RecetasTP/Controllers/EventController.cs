﻿using DAO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasTP.Controllers
{
    public class EventController : Controller
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        [Route("chef/events")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("chef/events")]
        [HttpPost]
        public IActionResult Add(AddEventModel e, IFormFile image)
        {
            e.ChefId = (int)HttpContext.Session.GetInt32("userId");
            _eventService.Add(e, image);
            return View();
        }

    }

    
}
