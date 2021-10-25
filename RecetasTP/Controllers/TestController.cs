using DAO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecetasTP.Controllers
{
    public class TestController : Controller
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        
        public IActionResult Index()
        {
            // Inicializa todo lo necesario manualmente  para usar el servicio y el contexto.
            //_20212C_TPContext ctx = new _20212C_TPContext();
            //DAO.Repositories.UserRepository userRepo = new DAO.Repositories.UserRepository(ctx);
            //TestService testService = new TestService(userRepo);

            List<Usuario> users = _testService.GetAll();

            // Guardar variable en sesion
            HttpContext.Session.SetString("Nombre", "Ramiro Gimenez");
            HttpContext.Session.SetInt32("Edad", 27);

            // Recuperar variable de sesion
            var nombre = HttpContext.Session.GetString("Nombre");
            var edad = HttpContext.Session.GetInt32("Edad");


            return View(users);
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

            // Llama al servicio correspondiente para guardar el usuario
            _testService.addUser(user1);

            return View("/Views/Home/Index.cshtml");
        }

    }
}


