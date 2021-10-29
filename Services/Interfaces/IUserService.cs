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
        public void addUser(AddUserModel user);
        public User getUserById(int id);
        public void deleteUser(User user);
        public void modifyUser(User user);
        public bool validateUser(string email, string password);
        public User getUserByEmail(string email);
        public bool isMailAvaiable(string mail);
        public bool isValidPassword(string pass);
        public string CreateMD5(string pass);
    }
}
