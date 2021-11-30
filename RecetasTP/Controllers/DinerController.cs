using DAO.Entities;
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
        private IRatingService _ratingService;

        public DinerController(IRecipeService recipeService, IEventService eventService, 
                                IUserService userService, IBookingService bookingService,
                                IRatingService ratingService)
        {
            _recipeService = recipeService;
            _eventService = eventService;
            _userService = userService;
            _bookingService = bookingService;
            _ratingService = ratingService;
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

            List<AvailableEvent> model = _eventService.GetAvailableEvents();

            return View(model);
        }

        [Route("/diner/book/{id}")]
        [HttpGet]
        public IActionResult ConfirmBook(int id)
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            ViewBag.RecipeList = _recipeService.GetRecipesFromEventId(id);
            Event ev = _eventService.GetById(id);

            ConfirmBookViewModel model = new ConfirmBookViewModel()
            {
                evnt = ev,
                evntChef = _userService.GetById(ev.ChefId),
                ReservedAmount = 0,
                RecipeId = 0,
                AvailableSpots = (ev.DinersAmount - _eventService.GetReservedSpotsById(id))
            };

            return View(model);
        }

        [Route("/diner/book")]
        [HttpPost]
        public IActionResult ConfirmBook(ConfirmBookViewModel model)
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            int dinerId = (int)HttpContext.Session.GetInt32("userId");

            Booking booking = new Booking()
            {
                EventId = model.evnt.EventId,
                DinerId = dinerId,
                RecipeId = model.RecipeId,
                DinersAmount = model.ReservedAmount,
                CreationDate = DateTime.Now,
                Diner = _userService.GetById(dinerId),
                Event = _eventService.GetById(model.evnt.EventId),
                Recipe = _recipeService.GetRecipeById(model.RecipeId),
            };

            _bookingService.Add(booking);
            TempData["Message"] = "Reserva realizada exitosamente.";
            TempData["AlertType"] = "alert-success";
            return RedirectToAction("Book");
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

        [Route("/diner/comments/{id}")]
        public IActionResult Comments(int id) 
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            var even = _eventService.GetById(id);
            Rating model = new Rating()
            {
                EventId = even.EventId,
                Event = even
            };
            return View(model);            
        }

        [HttpPost]
        public IActionResult SendComment(Rating rating) 
        {
            if (ModelState.IsValid) 
            {
                rating.DinerId = (int)HttpContext.Session.GetInt32("userId");
                _ratingService.Add(rating);
                TempData["Message"] = "Comentario enviado exitosamente.";
                TempData["AlertType"] = "alert-success";
                return RedirectToAction(nameof(MyBookings));
            }
            TempData["Message"] = "Error, intente nuevamente.";
            TempData["AlertType"] = "alert-danger";
            return RedirectToAction(nameof(Comments));
        }
    }
}
