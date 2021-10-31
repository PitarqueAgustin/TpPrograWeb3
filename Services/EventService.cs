using DAO.Entities;
using DAO.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepo;
        private IUserRepository _userRepo;

        public EventService(IEventRepository eventRepo, IUserRepository userRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
        }

        public void Add(AddEventModel e, IFormFile image)
        {
            string imageName = CopyImage(image);
            User chef = _userRepo.GetById(e.ChefId);

            Event newEvent = new Event
            {
                Chef = chef,
                ChefId = chef.UserId,
                CreatedBy = chef.UserId.ToString(),
                CreatedDate = DateTime.Now,
                Date = e.Date,
                Description = e.Description,
                DinersAmount = e.DinersAmount,
                Location = e.Location,
                ModifiedBy = chef.UserId.ToString(),
                ModifiedDate = DateTime.Now,
                Name = e.Name,
                Picture = imageName,
                Price = e.Price,
                State = (int)State.Pending,

                //ICollection<Booking>
                //ICollection<EventsRecipe>
                //ICollection<Rating>
            };

            _eventRepo.Add(newEvent);
        }

        public void Delete(Event e)
        {
            _eventRepo.Delete(e);
        }

        public List<Event> GetAll()
        {
            return _eventRepo.GetAll();
        }

        public Event GetById(int id)
        {
            return _eventRepo.GetById(id);
        }

        public string CopyImage(IFormFile image)
        {
            _ = new Tbl_News();
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName); //Set Key Name
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName); //Get url To Save
                var stream = new FileStream(SavePath, FileMode.Create);
                image.CopyTo(stream);
                return ImageName;
        }
        
        internal class Tbl_News
        {
        }

        public enum State
        {
            Pending = 1,
            Finished = 2,
            Cancelled = 3
        }
    }
}
