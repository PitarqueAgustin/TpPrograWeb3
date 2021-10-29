using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DAO.Entities;

namespace RecetasTP.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index ()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.ValidateUser(model.Email, model.Password))
                {
                    var user = _userService.GetUserByEmail(model.Email);
                    HttpContext.Session.SetInt32("userId", user.UserId);
                    HttpContext.Session.SetInt32("roleId", user.Rol);
                    TempData["value"] = $"Bienvenido, {user.Name}";

                    return RedirectToAction("Index", "Default");
                }

                ModelState.AddModelError(string.Empty, "Usuario no valido");
                return View(model);
            }

            return View();
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Default");
        }
    }
}
