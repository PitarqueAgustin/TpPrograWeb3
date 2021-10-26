using DAO.Models;
using DAO.Repositories;
using DAO.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class TestService : ITestService
    {
        private ITestRepository _testRepo;

        public TestService(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        public List<Usuario> GetAll()
        {
            return _testRepo.GetAll();
        }

        public void addUser(Usuario user)
        {
            _testRepo.AddNew(user);
        }

        public void deleteUser(Usuario user)
        {
            _testRepo.DeleteUser(user);
        }

        public Usuario getById(int id)
        {
            return _testRepo.getById(id);
        }

        public void modifyUser(Usuario user)
        {
            Usuario userDB = _testRepo.getById(user.IdUsuario);

            if (userDB == null)
            {
                throw new ArgumentException("Id inválido");
            }

            userDB.Nombre = user.Nombre;
            userDB.Password = user.Password;
            userDB.Email = user.Email;
            userDB.Perfil = user.Perfil;
            //userDB.FechaRegistracion= user.FechaRegistracion;

            _testRepo.SaveChanges();
        }
    }
}
