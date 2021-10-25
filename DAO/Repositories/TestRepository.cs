using DAO.Models;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public class TestRepository : ITestRepository
    {
        private _20212C_TPContext _ctx;

        public TestRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public List<Usuario> GetAll()
        {
            return _ctx.Usuarios.OrderBy(o => o.Nombre).ToList();
        }

        public void AddNew(Usuario user1)
        {
            // Agrega al contexto el user1
            _ctx.Usuarios.Add(user1);
            
            // Guarda en la DB el contexto
            _ctx.SaveChanges();
        }
    }
}
