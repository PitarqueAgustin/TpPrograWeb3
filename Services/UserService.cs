using DAO.Entities;
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

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public void addUser(AddUserModel userModel)
        {
            User newUser = new User();
            newUser.Name = userModel.Name;
            newUser.Email = userModel.Email;
            newUser.Password = userModel.Password;
            newUser.Rol = userModel.Rol;
            newUser.RegistrationDate = DateTime.Now;

            _userRepo.AddNewUser(newUser);
        }

        public void deleteUser(User user)
        {
            _userRepo.DeleteUser(user);
        }

        public User getUserById(int id)
        {
            return _userRepo.getUserById(id);
        }

        public void modifyUser(User user)
        {
            User userDB = _userRepo.getUserById(user.UserId);

            if (userDB == null)
            {
                throw new ArgumentException("Id inválido");
            }

            userDB.Name = user.Name;
            userDB.Password = user.Password;
            userDB.Email = user.Email;
            userDB.Rol = user.Rol;
            //userDB.FechaRegistracion= user.FechaRegistracion;

            _userRepo.SaveChanges();
        }

        public bool validateUser(string email, string password)
        {
            return _userRepo.ValidateUSer(email, password);
        }

        public User getUserByEmail(string email)
        {
            return _userRepo.getUserByEmail(email);
        }

        public bool isMailAvaiable(string mail)
        {
            return _userRepo.isMailAvaiable(mail);
        }
    }
}
