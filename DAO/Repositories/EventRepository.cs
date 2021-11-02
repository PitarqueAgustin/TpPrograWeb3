using DAO.Entities;
using DAO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public void Add(Event e)
        {
            _ctx.Events.Add(e);
            SaveChanges();
        }

        public void Delete(Event e)
        {
            SaveChanges();
        }

        public List<Event> GetAll()
        {
            return _ctx.Events.OrderBy(e => e.CreatedDate).ToList();
        }

        public List<Event> GetAvailables()
        {
            // Query que funciona en SQL
            //select e.EventId, SUM(b.DinersAmount)
            //from Events e
            //inner join bookings b on e.EventId = b.EventId
            //where e.Date > GETDATE()
            //group by e.EventId

            var query = from e in _ctx.Events.Include("Bookings")
                        join b in _ctx.Bookings on e.EventId equals b.EventId
                        where e.Date > DateTime.Now.Date && e.State == 1
                        //group e by e.EventId into events
                        select e;
            return query.ToList();
        }

        public Event GetById(int id)
        {
            return _ctx.Events.Find(id);
        }

        public List<Event> GetListByUser(int chefId)
        {
            var list = _ctx.Events.Where(e => e.ChefId == chefId);

            if (list.Count() > 0)
                return list.ToList();
            else
                return new List<Event>();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }

}
