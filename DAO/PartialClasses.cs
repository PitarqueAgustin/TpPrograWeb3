using System;
using System.ComponentModel.DataAnnotations;

namespace DAO.Entities
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        // public string Password2 { get; set; }
    }

    [MetadataType(typeof(RecetaMetadata))]
    public partial class Receta
    {
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Email obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        public string Password { get; set; }

    }
}