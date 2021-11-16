using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        public List<Booking> GetListBookingsForDinerId(int dinerId);
        public void Add(Booking booking);
    }
}
