using DAO.Entities;
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
            List<User> users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        //[Route("register")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost()]
        [Route("register")]
        public IActionResult Add(AddUserModel userModel) // binding automático entre el modelo y la entrada de datos a travez del campo name del form
        {
            if (_userService.isValidPassword(userModel.Password))
            {
                if (_userService.isMailAvaiable(userModel.Email))
                {
                    _userService.addUser(userModel);
                    return Redirect("/user");
                }
                ModelState.AddModelError(string.Empty, "El mail ingresado no está disponible");
                return View(userModel);
            }
            
            ModelState.AddModelError(string.Empty, "Password no cumple con expresión regular");
            return View(userModel);
        }

        [HttpGet]
        // [HttpDelete]
        // [Route("User/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            User user = _userService.getUserById(id);
            if (user == null)
            {
                throw new ArgumentException("Id inválido");
            }

            _userService.deleteUser(user);
            return Redirect("/user");
        }

        //[HttpPut]
        [HttpGet]
        public IActionResult Modify(int id)
        {
            try
            {
                User user = _userService.getUserById(id);
                return View(user);
            }
            catch (ArgumentException)
            {
                return Redirect("/user");
            }
        }

        [HttpPost]
        //[HttpPut]
        public IActionResult Modify(User user)
        {
            _userService.modifyUser(user);
            return Redirect("/user");
        }

        public IActionResult Test()
        {
            // Inicializa todo lo necesario manualmente  para usar el servicio y el contexto.
            //_20212C_TPContext ctx = new _20212C_TPContext();
            //DAO.Repositories.UserRepository userRepo = new DAO.Repositories.UserRepository(ctx);
            //UserService userService = new UserService(userRepo);

            // Guardar variable en sesion
            HttpContext.Session.SetString("Nombre", "Ramiro Gimenez");
            HttpContext.Session.SetInt32("Edad", 27);

            // Recuperar variable de sesion
            var nombre = HttpContext.Session.GetString("Nombre");
            var edad = HttpContext.Session.GetInt32("Edad");

            return Redirect("/user");
        }
    }
}


