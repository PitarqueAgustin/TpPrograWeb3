using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecetasTP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DAO.Models;

namespace RecetasTP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        // Instancia el contexto del proyecto DAO
        _20212C_TPContext ctx = new _20212C_TPContext();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NewUser()
        {
            // Instancia y llena el objeto Usuario del modelo Usuario dentro de DAO/Models
            Usuario user1 = new Usuario();
            user1.Nombre = "Juan";
            user1.Password = "1234";
            user1.Email = "email@email.com";
            user1.Perfil = 123;
            user1.FechaRegistracion = DateTime.Now;

            // Agrega al contexto el user1
            ctx.Usuarios.Add(user1);

            // Guarda en la DB el contexto
            ctx.SaveChanges();


            return View("/Views/Home/Index.cshtml");
        }

        public IActionResult Index()
        {
            // Guardar variable en sesion
            //HttpContext.Session.SetString("Nombre", "Ramiro Gimenez");
            //HttpContext.Session.SetInt32("Edad", 27);

            // Recuperar variable de sesion
            //var nombre = HttpContext.Session.GetString("Nombre");
            //var edad = HttpContext.Session.GetInt32("Edad");

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
