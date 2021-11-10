using DAO.Entities;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private _20212C_TPContext _ctx;

        public RatingRepository(_20212C_TPContext ctx) 
        {
            _ctx = ctx;
        }

        public void Add(Rating rating)
        {
            _ctx.Ratings.Add(rating);

            _ctx.SaveChanges();
        }
    }
}
