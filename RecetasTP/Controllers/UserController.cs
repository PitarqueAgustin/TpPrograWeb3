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
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        public IActionResult Index()
        {
            // Inicializa todo lo necesario manualmente  para usar el servicio y el contexto.
            //_20212C_TPContext ctx = new _20212C_TPContext();
            //DAO.Repositories.UserRepository userRepo = new DAO.Repositories.UserRepository(ctx);
            //UserService userService = new UserService(userRepo);

            List<Usuario> users = _userService.GetAllUsers();

            // Guardar variable en sesion
            HttpContext.Session.SetString("Nombre", "Ramiro Gimenez");
            HttpContext.Session.SetInt32("Edad", 27);

            // Recuperar variable de sesion
            var nombre = HttpContext.Session.GetString("Nombre");
            var edad = HttpContext.Session.GetInt32("Edad");


            return View(users);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Usuario user) // binding automático entre el modelo y la entrada de datos a travez del campo name del form
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
            _userService.addUser(user);

            return Redirect("/user");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Usuario user = _userService.getUserById(id);
            if (user == null)
            {
                throw new ArgumentException("Id inválido");
            }

            _userService.deleteUser(user);
            return Redirect("/user");
        }

        [HttpGet]
        public IActionResult Modify(int id)
        {
            try
            {
                Usuario user = _userService.getUserById(id);
                return View(user);
            }
            catch (ArgumentException)
            {
                return Redirect("/user");
            }
        }

        [HttpPost]
        public IActionResult Modify(Usuario user)
        {
            _userService.modifyUser(user);
            return Redirect("/user");
        }


    }
}


