using System;
using System.ComponentModel.DataAnnotations;

namespace DAO
{
    public class UserMetadata
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
        
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