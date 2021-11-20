﻿using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DAO.Entities;
using RecetasTP.Filters;

namespace RecetasTP.Controllers
{
    [LayoutActionFilter]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");

            if (ModelState.IsValid)
            {
                if (_userService.Validate(model.Email, model.Password))
                {
                    var user = _userService.GetByEmail(model.Email);
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



        [HttpGet]
        [Route("register")]
        public IActionResult Add()
        {
            ViewBag.Layout = HttpContext.Session.GetString("layout");
            return View();
        }

        [HttpPost()]
        [Route("register")]
        public IActionResult Add(AddUserModel userModel) // binding automático entre el modelo y la entrada de datos a travez del campo name del form
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsValidPassword(userModel.Password))
                {
                    if (_userService.IsMailAvailable(userModel.Email))
                    {
                        _userService.Add(userModel);
                        return Redirect("/default");
                    }
                    ModelState.AddModelError(string.Empty, "El mail ingresado no está disponible");
                    return View(userModel);
                }
            }

            ModelState.AddModelError(string.Empty, "Password no cumple con expresión regular");
            return View(userModel);
        }
    }
}
