using DAO.Entities;
using System.Collections.Generic;

namespace DAO.Repositories.Interfaces
{
    public interface IEventRepository
    {
        public List<Event> GetAll();
        public void Add(Event e);
        public Event GetById(int id);
        public void Delete(Event e);
        public void SaveChanges();
    }
}
