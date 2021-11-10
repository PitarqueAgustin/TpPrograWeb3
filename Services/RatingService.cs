using DAO.Entities;
using DAO.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService : IRatingService
    {
        private IRatingRepository _ratingRepo;

        public RatingService(IRatingRepository ratingRepo) 
        {
            _ratingRepo = ratingRepo;
        }

        public void Add(Rating rating)
        {
            _ratingRepo.Add(rating);
        }
    }
}
