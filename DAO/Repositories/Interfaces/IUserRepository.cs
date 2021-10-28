using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public List<Usuario> GetAllUsers();
        public void AddNewUser(Usuario user);
        public void SaveChanges();
        public Usuario getUserById(int id);
        public void DeleteUser(Usuario user);
        public bool ValidateUSer(string email, string password);
        public Usuario getUserByEmail(string email);
    }
}
