using DAO.Entities;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Event GetById(int id)
        {
            return _ctx.Events.Find(id);
        }

        public List<Event> GetListByUser(int chefId)
        {
            var list = _ctx.Events.Where(e => e.ChefId == chefId);
            return list.ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }

}
