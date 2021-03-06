using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        public List<Booking> GetListBookingsForDinerId(int dinerId);
        public void Add(Booking booking);
    }
}
