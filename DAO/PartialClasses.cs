using Microsoft.AspNetCore.Http;
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

    [ModelMetadataType(typeof(RatingMetadata))]
    public partial class Rating
    {
    }

    [ModelMetadataType(typeof(LoginMetadata))]
    public partial class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [ModelMetadataType(typeof(AddUserMetadata))]
    public partial class AddUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Rol { get; set; }
    }

    [ModelMetadataType(typeof(AddRecipeMetadata))]
    public partial class AddRecipeModel 
    {
        public int RecipeId { get; set; }
        public int ChefId { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int RecipeTypeId { get; set; }
    }

    [ModelMetadataType(typeof(AddEventMetadata))]
    public partial class AddEventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DinersAmount { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int ChefId { get; set; }
        public IFormFile Picture { get; set; }
    }

}