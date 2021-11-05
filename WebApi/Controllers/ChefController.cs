using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    public class ChefController : Controller
    {
        private IEventService _eventService;

        public ChefController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("/chef/cancel")]
        public void Index(int eventId, int chefId)
        {
            if (chefId == 0)
            {
                throw new ArgumentException("Inválido");
            }

            _eventService.Delete(eventId, chefId);
        }


    }
}
