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
        public List<User> GetAll();
        public void Add(User user);
        public void SaveChanges();
        public User GetById(int id);
        public void Delete(User user);
        public bool Validate(string email, string password);
        public User GetByEmail(string email);
        public bool IsMailAvailable(string mail);
    }
}
