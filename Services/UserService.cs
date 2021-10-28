using DAO.Models;
using DAO.Repositories;
using DAO.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<Usuario> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public void addUser(Usuario user)
        {
            _userRepo.AddNewUser(user);
        }

        public void deleteUser(Usuario user)
        {
            _userRepo.DeleteUser(user);
        }

        public Usuario getUserById(int id)
        {
            return _userRepo.getUserById(id);
        }

        public void modifyUser(Usuario user)
        {
            Usuario userDB = _userRepo.getUserById(user.IdUsuario);

            if (userDB == null)
            {
                throw new ArgumentException("Id inválido");
            }

            userDB.Nombre = user.Nombre;
            userDB.Password = user.Password;
            userDB.Email = user.Email;
            userDB.Perfil = user.Perfil;
            //userDB.FechaRegistracion= user.FechaRegistracion;

            _userRepo.SaveChanges();
        }

        public bool validateUser(string email, string password)
        {
            return _userRepo.ValidateUSer(email, password);
        }

        public Usuario getUserByEmail(string email)
        {
            return _userRepo.getUserByEmail(email);
        }
    }
}
