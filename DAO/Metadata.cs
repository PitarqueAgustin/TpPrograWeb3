using System;
using System.ComponentModel.DataAnnotations;

namespace DAO.Entities
{
    public class UserMetadata
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Rol { get; set; }
    }

    public class LoginMetadata
    {
        [Required(ErrorMessage = "Email obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; }
    }

    public class AddUserMetadata
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

    public class AddRecipeMetadata 
    {
    
    }

}