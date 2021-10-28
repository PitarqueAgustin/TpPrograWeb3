using DAO.Models;
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
        public List<Usuario> GetAllUsers();
        public void addUser(Usuario user);
        public Usuario getUserById(int id);
        public void deleteUser(Usuario user);
        public void modifyUser(Usuario user);
        public bool validateUser(string email, string password);
        public Usuario getUserByEmail(string email);
    }
}
