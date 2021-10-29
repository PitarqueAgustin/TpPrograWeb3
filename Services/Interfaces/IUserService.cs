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
        public List<User> GetAll();
        public void Add(AddUserModel user);
        public User GetById(int id);
        public void Delete(User user);
        public void Modify(User user);
        public bool Validate(string email, string password);
        public User GetByEmail(string email);
        public bool IsMailAvailable(string mail);
        public bool IsValidPassword(string pass);
        public string CreateMD5(string pass);
    }
}
