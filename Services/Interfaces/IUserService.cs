using DAO.Entities;
using DAO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public void AddUser(AddUserModel user);
        public User GetUserById(int id);
        public void DeleteUser(User user);
        public void ModifyUser(User user);
        public bool ValidateUser(string email, string password);
        public User GetUserByEmail(string email);
        public bool IsMailAvaiable(string mail);
        public bool IsValidPassword(string pass);
        public string CreateMD5(string pass);
    }
}
