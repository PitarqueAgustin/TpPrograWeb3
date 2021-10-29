﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAO.Entities
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    [MetadataType(typeof(LoginMetadata))]
    public partial class LoginModel
    {
        [Required(ErrorMessage = "Email obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; }
    }

    [MetadataType(typeof(AddUserMetadata))]
    public partial class AddUserModel
    {
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Los passwords no son iguales")]
        [Required(ErrorMessage = "Password obligatorio")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Perfil obligatorio")]
        public int Rol { get; set; }
    }

    [MetadataType(typeof(AddRecipeMetadata))]
    public partial class AddRecipeModel 
    {
        [Required]
        public int ChefId { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int RecipeTypeId { get; set; }
    }
}