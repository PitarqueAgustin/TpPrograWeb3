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
    }
}
