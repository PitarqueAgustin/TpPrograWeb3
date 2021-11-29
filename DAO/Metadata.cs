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

    public class RatingMetadata
    {
        [Required]
        [Range(1, 5, ErrorMessage = "Mínimo {1}, máximo {2} valor de puntuación.")]
        public int Rating1 { get; set; }
        [Required]
        public string Comments { get; set; }
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
        [RegularExpression(@"^([A-Z])(?=.*\d)(?=.*[a - zA - Z]).{7,}$",
         ErrorMessage = "No cumple con restricción clave")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Los passwords no son iguales")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^([A-Z])(?=.*\d)(?=.*[a - zA - Z]).{7,}$",
         ErrorMessage = "No cumple con restricción clave")]
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
        [Required(ErrorMessage = "Campo obligatorio")]
        public int CookingTime { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Ingredients { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int RecipeTypeId { get; set; }
    }

    public class AddEventMetadata
    {
        [StringLength(50, ErrorMessage = "El campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200, ErrorMessage = "El campo no puede tener más de {1} caracteres.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [CurrentDate(ErrorMessage = "La fecha tiene que ser posterior o igual a la fecha actual")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, 500, ErrorMessage = "Mínimo {1}, máximo {2} comensales.")]
        public int DinersAmount { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "El campo no puede tener más de {1} caracteres.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]

        [Range(1, 1000000000.00, ErrorMessage = "Mínimo {1}, máximo {2} de precio.")] // PRecio hardcodeado en 1billon en vez de 16,2
        public decimal Price { get; set; }
    }

}