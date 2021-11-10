using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public void Add(Rating rating);
    }
}
