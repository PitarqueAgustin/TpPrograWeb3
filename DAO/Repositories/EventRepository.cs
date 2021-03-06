using DAO.Entities;
using DAO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO.Repositories
{
    public class EventRepository : IEventRepository
    {
        private _20212C_TPContext _ctx;
        public EventRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public EntityEntry<Event> Add(Event e)
        {
            var rta = _ctx.Events.Add(e);
            SaveChanges();
            return rta;
        }

        public List<Event> GetAll()
        {
            return _ctx.Events.OrderBy(e => e.CreatedDate).Where(e => e.DeletedDate == null).ToList();
        }

        public List<Event> GetAvailables()
        {
            // Query que funciona en SQL
            //select e.EventId, SUM(b.DinersAmount)
            //from Events e
            //inner join bookings b on e.EventId = b.EventId
            //where e.Date > GETDATE()
            //group by e.EventId

            var query = from e in _ctx.Events
                        join b in _ctx.Bookings on e.EventId equals b.EventId into evts
                        from subEvts in evts.DefaultIfEmpty()
                        where e.Date > DateTime.Now.Date && e.State == 1 && e.DeletedDate == null
                        orderby e.ModifiedDate descending
                        //group e by e.EventId into events
                        select e;
            return query.ToList();
        }

        public Event GetById(int id)
        {
            return _ctx.Events.Find(id);
        }

        public List<Event> GetLastEventsEnded()
        {
            var query = _ctx.Events.Where(e => e.Ratings.Any()
                                            && e.State == 2
                                            && e.Date < DateTime.Now.Date
                                            && e.DeletedDate == null)
                                    .OrderByDescending(e => e.Date).Take(6);
            return query.ToList();
        }

        public List<Event> GetListByUser(int chefId)
        {
            var list = _ctx.Events.Where(e => e.ChefId == chefId && e.DeletedDate == null);

            if (list.Count() > 0)
                return list.OrderByDescending(o => o.ModifiedDate).ToList();
            else
                return new List<Event>();
        }

        public double GetAverageRating(int id)
        {
            var query = _ctx.Ratings.Where(r => r.EventId == id).Average(r => r.Rating1);
            return query;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public List<Rating> GetRatingForEventId(int id)
        {
            var query = _ctx.Ratings.Where(r => r.EventId == id).ToList();
            return query;
        }

        public int GetReservedSpotsById(int eventId)
        {
            var query = _ctx.Bookings.Where(b => b.EventId == eventId)
                .Sum(e => e.DinersAmount);

            return query;
        }

        public void Update(Event ev)
        {
            ev.ModifiedBy = ev.ChefId.ToString();
            ev.ModifiedDate = DateTime.Now;

            _ctx.Events.Update(ev);
            _ctx.SaveChanges();
        }

        public void Remove(int id)
        {
            Event ev = _ctx.Events.Find(id);
            ev.DeletedBy = ev.ChefId.ToString();
            ev.DeletedDate = DateTime.Now;
            ev.ModifiedBy = ev.ChefId.ToString();
            ev.ModifiedDate= DateTime.Now;
            ev.State = (int)State.Cancelado;
            _ctx.Events.Update(ev);
            _ctx.SaveChanges();
        }

        public void AddEventRecipe(EventsRecipe eventsRecipe)
        {
            _ctx.EventsRecipes.Add(eventsRecipe);
            _ctx.SaveChanges();
        }

        public void DeleteAllEventRecipe(int eventId) 
        {
            _ctx.EventsRecipes.RemoveRange(GetEventsRecipes(eventId));
            _ctx.SaveChanges();
        }

        public bool IsEventBelongToUser(int eventId, int chefId)
        {
            return _ctx.Events.Where(e => e.EventId == eventId && e.ChefId == chefId).Any();
        }

        public List<EventsRecipe> GetEventsRecipes(int eventId)
        {
            return _ctx.EventsRecipes.Where(er=> er.EventId == eventId).ToList();
        }

        public enum State
        {
            Pendiente = 1,
            Finalizado = 2,
            Cancelado = 3
        }
    }
}
