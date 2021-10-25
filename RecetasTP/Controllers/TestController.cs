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

        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(Usuario user) // binding automático entre el modelo y la entrada de datos a travez del campo name del form
        {
            // Instancia y llena el objeto Usuario del modelo Usuario dentro de DAO/Models manualmente
            //Usuario user = new Usuario();
            //user.Nombre = "Juan";
            //user.Password = "1234";
            //user.Email = "email@email.com";
            //user.Perfil = 123;
            //user.FechaRegistracion = DateTime.Now;

            user.FechaRegistracion = DateTime.Now;
            // Llama al servicio correspondiente para guardar el usuario
            _testService.addUser(user);

            return Redirect("/test");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Usuario user = _testService.getById(id);
            _testService.deleteUser(user);
            return Redirect("/test");
        }


    }
}


