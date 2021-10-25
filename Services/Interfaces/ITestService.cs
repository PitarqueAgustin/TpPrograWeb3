using DAO.Models;
using DAO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITestService
    {
        public List<Usuario> GetAll();
        public void addUser(Usuario user);
        public Usuario getById(int id);
        public void deleteUser(Usuario user);
    }
}
