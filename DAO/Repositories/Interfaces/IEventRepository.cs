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
        public List<Event> GetListByUser(int chefId);
        public List<Event> GetAvailables();
        public List<Event> GetLastEventsEnded();
        public double GetAverageRating(int id);
    }
}
