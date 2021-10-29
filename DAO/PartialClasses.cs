using Microsoft.AspNetCore.Mvc;
using System;
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
}