using DAO.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using static Services.EventService;

namespace Services.Interfaces
{
    public interface IEventService
    {
        public List<Event> GetAll();
        public void Add(AddEventModel e, IFormFile image, string[] recipesId);
        public Event GetById(int id);
        public void Delete(int eventId, int chefId);
        public List<Event> GetListByUser(int chefId);
        public Tuple<List<Event>, List<int>> GetAvailables();
        public List<Event> GetLastEventsEnded();
        public List<double> GetAverageRating(List<Event> lastEvents);
        public List<string> GetCommentsForEventId(int id);
        public List<int> GetReservedSpots(List<Event> eventList);
        public void Update(Event ev, IFormFile image);
        public List<State> getStates();
        public void Remove(int id);
        public void AddEventRecipe(EventsRecipe eventRecipe);
    }
}
