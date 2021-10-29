using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAO.Entities
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }

    [ModelMetadataType(typeof(LoginMetadata))]
    public partial class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [MetadataType(typeof(AddUserMetadata))]
    public partial class AddUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
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