using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("/chef/cancel")]
        public IActionResult Index(int eventId, int chefId)
        {
            if (chefId == 0)
            {
                throw new ArgumentException("Inválido");
            }

            if(_eventService.IsEventBelongToUser(eventId, chefId))
            {
                _eventService.Delete(eventId, chefId);
                return Ok();
            }
            else
            {
                var message = string.Format("El id del evento no pertenece al id del usuario", eventId, chefId);
                HttpError err = new HttpError(message);
                return StatusCode(500, err);
            }

        }


    }
}
