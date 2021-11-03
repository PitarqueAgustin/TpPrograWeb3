using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecetasTP.Filters;
using RecetasTP.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class DinerController : Controller
    {
        private IRecipeService _recipeService;
        private IEventService _eventService;
        private IUserService _userService;
        private IBookingService _bookingService;

        public DinerController(IRecipeService recipeService, IEventService eventService, 
                                IUserService userService, IBookingService bookingService)
        {
            _recipeService = recipeService;
            _eventService = eventService;
            _userService = userService;
            _bookingService = bookingService;
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

        [Route("/diner/bookings")]
        public IActionResult MyBookings()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            int userId = (int) HttpContext.Session.GetInt32("userId");
            var listBookings = _bookingService.GetListBookingsForDinerId(userId);
            List<BookingsModel> model = new List<BookingsModel>();
            foreach (var book in listBookings) 
            {
                book.Event = _eventService.GetById(book.EventId);
                model.Add(new BookingsModel { 
                    EventId = book.EventId,
                    NameEvent = book.Event.Name,
                    DateEvent = book.Event.Date,
                    DescriptionEvent = book.Event.Description,
                    StateEvent = BookingsModel.GetState(book.Event.State),
                    Cancelated = book.Event.State == 3, //cancelado
                    Finished = book.Event.State == 2 //finalizado
                });
            }
            return View(model);
        }
    }
}
