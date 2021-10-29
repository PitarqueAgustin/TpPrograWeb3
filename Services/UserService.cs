using DAO.Entities;
using DAO.Repositories;
using DAO.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public void Add(AddUserModel userModel)
        {
            User newUser = new User();
            newUser.Name = userModel.Name;
            newUser.Email = userModel.Email;
            newUser.Password = CreateMD5(userModel.Password);
            newUser.Rol = userModel.Rol;
            newUser.RegistrationDate = DateTime.Now;

            _userRepo.Add(newUser);
        }

        public void Delete(User user)
        {
            _userRepo.Delete(user);
        }

        public User GetById(int id)
        {
            return _userRepo.GetById(id);
        }

        public void Modify(User user)
        {
            User userDB = _userRepo.GetById(user.UserId);

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

        public bool Validate(string email, string password)
        {
            password = CreateMD5(password);
            return _userRepo.Validate(email, password);
        }

        public User GetByEmail(string email)
        {
            return _userRepo.GetByEmail(email);
        }

        public bool IsMailAvailable(string mail)
        {
            return _userRepo.IsMailAvailable(mail);
        }

        public bool IsValidPassword(string pass)
        {
            Regex regex = new Regex(@"^([A-Z])(?=.*\d)(?=.*[a - zA - Z]).{7,}$");
            bool isValidated = regex.IsMatch(pass);
            return isValidated;
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().Substring(0, 30);
            }
        }
    }
}
