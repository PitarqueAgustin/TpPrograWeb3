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

        public void addUser(Usuario user1)
        {
            _testRepo.AddNew(user1);
        }
    }
}
