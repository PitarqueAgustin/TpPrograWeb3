using DAO.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventService
    {
        public List<Event> GetAll();
        public void Add(AddEventModel e, IFormFile image);
        public Event GetById(int id);
        public void Delete(Event e);
    }
}
