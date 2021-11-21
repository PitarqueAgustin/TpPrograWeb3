using DAO.Entities;
using DAO.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepo;
        private IUserRepository _userRepo;
        private IRecipeRepository _recipeRepo;

        public EventService(IEventRepository eventRepo, IUserRepository userRepo,
            IRecipeRepository recipeRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
            _recipeRepo = recipeRepo;
        }

        public void Add(AddEventModel e, IFormFile image, string[] recipesId)
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
                State = (int)State.Pendiente,

                //ICollection<Booking>
                //ICollection<EventsRecipe>
                //ICollection<Rating>
            };

            var rta = _eventRepo.Add(newEvent);

            foreach (string recipeId in recipesId) 
            {
                _eventRepo.AddEventRecipe(new EventsRecipe(){
                    EventId = rta.Entity.EventId,
                    RecipeId = Convert.ToInt32(recipeId)
                });
            }
        }

        public void Delete(int eventId, int chefId)
        {
            Event ev = _eventRepo.GetById(eventId);
            User chef = _userRepo.GetById(chefId);

            ev.ModifiedDate = DateTime.Now;
            ev.ModifiedBy = chef.UserId.ToString();
            ev.DeletedDate = DateTime.Now;
            ev.DeletedBy = chef.UserId.ToString();
            ev.State = (int)State.Cancelado;

            _eventRepo.Delete(ev);
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

        public List<Event> GetListByUser(int chefId)
        {
            return _eventRepo.GetListByUser(chefId);
        }

        public List<AvailableEvent> GetAvailableEvents()
        {
            List<Event> eventList = _eventRepo.GetAvailables().Distinct().ToList(); ;
            List<AvailableEvent> availableEvents = new List<AvailableEvent>();
            for(int i = 0; i < eventList.Count; i++)
            {
                AvailableEvent temp = new AvailableEvent()
                {
                    Ev = eventList[i],
                    FreeSlots = eventList[i].DinersAmount - _eventRepo.GetReservedSpotsById(eventList[i].EventId),
                };

                if (temp.FreeSlots > 0)
                {
                    availableEvents.Add(temp);
                }
            }
            
            return availableEvents;
        }
        
        public List<int> GetReservedSpots(List<Event> eventList)
        {
            List<int> reservedSpots = new List<int>();
            for (int i = 0; i < eventList.Count; i++)
            {
                reservedSpots.Add(_eventRepo.GetReservedSpotsById(eventList[i].EventId));
            }

            return reservedSpots;
        }

        public List<Event> GetLastEventsEnded()
        {
            List<Event> lastEvents = _eventRepo.GetLastEventsEnded();
            return lastEvents;
        }

        public List<double> GetAverageRating(List<Event> lastEvents)
        {
            List<double> avgEventRatings = new List<double>(new double[lastEvents.Count]);
            for (int i = 0; i < lastEvents.Count; i++)
            {
                avgEventRatings[i] = _eventRepo.GetAverageRating(lastEvents[i].EventId);
            }
            return avgEventRatings;
        }

        public List<string> GetCommentsForEventId(int id)
        {
            return _eventRepo.GetCommentsForEventId(id);
        }

        public void Update(Event ev, IFormFile image, string[] recipesId)
        {
            if(image != null)
            {
                string imageName = CopyImage(image);
                ev.Picture = imageName;
            }
            
            _eventRepo.Update(ev);

            _eventRepo.DeleteAllEventRecipe(ev.EventId);

            foreach (string recipeId in recipesId)
            {
                _eventRepo.AddEventRecipe(new EventsRecipe()
                {
                    EventId = ev.EventId,
                    RecipeId = Convert.ToInt32(recipeId)
                });
            }
        }

        internal class Tbl_News
        {
        }

        public enum State
        {
            Pendiente = 1,
            Finalizado = 2,
            Cancelado = 3
        }

        public List<State> getStates()
        {
            var valuesAsList = Enum.GetValues(typeof(State)).Cast<State>().ToList();
            return valuesAsList;
        }

        public void Remove(int id)
        {
            _eventRepo.Remove(id);
        }

        public void AddEventRecipe(EventsRecipe eventRecipe)
        {
            throw new NotImplementedException();
        }

        public int GetReservedSpotsById(int id)
        {
            return _eventRepo.GetReservedSpotsById(id);
        }

        public bool IsEventBelongToUser(int eventId, int chefId)
        {
            return _eventRepo.IsEventBelongToUser(eventId, chefId);
        }

        public List<EventsRecipe> GetEventsRecipes(int eventId)
        {
            return _eventRepo.GetEventsRecipes(eventId);
        }
    }
}
