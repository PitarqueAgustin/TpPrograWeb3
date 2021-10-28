using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public void AddNewUser(User user);
        public void SaveChanges();
        public User getUserById(int id);
        public void DeleteUser(User user);
        public bool ValidateUSer(string email, string password);
        public User getUserByEmail(string email);
        public bool isMailAvaiable(string mail);
    }
}
