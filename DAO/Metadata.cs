using System;
using System.ComponentModel.DataAnnotations;

namespace DAO
{
    public class UserMetadata
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Perfil { get; set; }
        
        [Required]
        public string Password2 { get; set; }
    }

    public class RecetaMetadata
    {
        // Insert data anotations here
        // [Required]
        // [StringLength(50)]
        // Insert prop / method here
        // public Nullable<String> Nombre;
    }
}