using DAO.Entities;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public class UserRepository : IUserRepository
    {
        private _20212C_TPContext _ctx;

        public UserRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetAllUsers()
        {
            return _ctx.Users.OrderBy(o => o.Name).ToList();
        }

        public void AddNewUser(User user)
        {
            // Agrega al contexto el user
            _ctx.Users.Add(user);
            
            // Guarda en la DB el contexto
            SaveChanges();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public User getUserById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public void DeleteUser(User user)
        {
            _ctx.Users.Remove(user);
            SaveChanges();
        }

        public bool ValidateUSer(string email, string password)
        {
            return _ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password) != null;
        }

        public User getUserByEmail(string email)
        {
            return _ctx.Users.First(u => u.Email == email);
        }

        public bool isMailAvaiable(string mail)
        {
            bool mailRegistered = _ctx.Users.FirstOrDefault(u=> u.Email == mail) != null;
            return !mailRegistered;

        }
    }
}
