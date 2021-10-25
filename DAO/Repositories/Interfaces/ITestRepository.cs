﻿using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface ITestRepository
    {
        public List<Usuario> GetAll();
        public void AddNew(Usuario user);
        public void SaveChanges();
        public Usuario getById(int id);
        public void DeleteUser(Usuario user);
    }
}
