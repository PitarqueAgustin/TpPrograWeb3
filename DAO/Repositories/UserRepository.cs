using DAO.Models;
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

        public List<Usuario> GetAllUsers()
        {
            return _ctx.Usuarios.OrderBy(o => o.Nombre).ToList();
        }

        public void AddNewUser(Usuario user)
        {
            // Agrega al contexto el user
            _ctx.Usuarios.Add(user);
            
            // Guarda en la DB el contexto
            SaveChanges();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public Usuario getUserById(int id)
        {
            return _ctx.Usuarios.Find(id);
        }

        public void DeleteUser(Usuario user)
        {
            _ctx.Usuarios.Remove(user);
            SaveChanges();
        }

        public bool ValidateUSer(string email, string password)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password) != null;
        }

        public Usuario getUserByEmail(string email)
        {
            return _ctx.Usuarios.First(u => u.Email == email);
        }
    }
}
