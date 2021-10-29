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

        public List<User> GetAll()
        {
            return _ctx.Users.OrderBy(o => o.Name).ToList();
        }

        public void Add(User user)
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

        public User GetById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public void Delete(User user)
        {
            _ctx.Users.Remove(user);
            SaveChanges();
        }

        public bool Validate(string email, string password)
        {
            return _ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password) != null;
        }

        public User GetByEmail(string email)
        {
            return _ctx.Users.First(u => u.Email == email);
        }

        public bool IsMailAvailable(string mail)
        {
            bool mailRegistered = _ctx.Users.FirstOrDefault(u=> u.Email == mail) != null;
            return !mailRegistered;

        }
    }
}
