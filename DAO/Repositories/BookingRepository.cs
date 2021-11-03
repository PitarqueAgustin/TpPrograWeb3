using DAO.Entities;
using DAO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private _20212C_TPContext _ctx;
        public BookingRepository(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public List<Booking> GetListBookingsForDinerId(int dinerId)
        {
            return _ctx.Bookings.Where(b => b.DinerId == dinerId).ToList();
        }
    }
}
