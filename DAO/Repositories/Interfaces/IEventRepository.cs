using DAO.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace DAO.Repositories.Interfaces
{
    public interface IEventRepository
    {
        public List<Event> GetAll();
        public EntityEntry<Event> Add(Event e);
        public Event GetById(int id);
        public void SaveChanges();
        public List<Event> GetListByUser(int chefId);
        public List<Event> GetAvailables();
        public List<Event> GetLastEventsEnded();
        public double GetAverageRating(int id);
        public List<Rating> GetRatingForEventId(int id);
        public int GetReservedSpotsById(int eventId);
        public void Update(Event ev);
        public void Remove(int id);
        public void AddEventRecipe(EventsRecipe eventsRecipe);
        public void DeleteAllEventRecipe(int eventId);
        public bool IsEventBelongToUser(int eventId, int chefId);
        public List<EventsRecipe> GetEventsRecipes(int eventId);
    }
}
