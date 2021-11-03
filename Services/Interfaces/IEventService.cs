using DAO.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IEventService
    {
        public List<Event> GetAll();
        public void Add(AddEventModel e, IFormFile image);
        public Event GetById(int id);
        public void Delete(int eventId, int chefId);
        public List<Event> GetListByUser(int chefId);
        public Tuple<List<Event>, List<int>> GetAvailables();
        public List<Event> GetLastEventsEnded();
        public List<double> GetAverageRating(List<Event> lastEvents);
        public List<string> GetCommentsForEventId(int id);
    }
}
