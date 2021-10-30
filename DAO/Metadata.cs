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
        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
    }

    public class AddUserMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Los passwords no son iguales")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Rol { get; set; }
    }

    public class AddRecipeMetadata 
    {
        [Required]
        public int ChefId { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
    }

    public class AddEventMetadata
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int DinersAmount { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Price { get; set; }
    }

}