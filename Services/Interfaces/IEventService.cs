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
        public List<Event> GetListByUser(int chefId);
        public List<Event> GetLastEventsEnded();
        public List<double> GetAverageRating(List<Event> lastEvents);
        public List<string> GetCommentsForEventId(int id);
        public List<int> GetReservedSpots(List<Event> eventList);
        public void Update(Event ev, IFormFile image, string[] recipes);
        public List<State> getStates();
        public void Remove(int id);
        public void AddEventRecipe(EventsRecipe eventRecipe);
        public int GetReservedSpotsById(int id);
        public List<AvailableEvent> GetAvailableEvents();
        public bool IsEventBelongToUser(int eventId, int chefId);
        public List<EventsRecipe> GetEventsRecipes(int chefId);

    }
}
