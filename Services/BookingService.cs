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
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void Add(Booking booking)
        {
            _bookingRepository.Add(booking);
        }

        public List<Booking> GetListBookingsForDinerId(int dinerId)
        {
            return _bookingRepository.GetListBookingsForDinerId(dinerId);
        }
    }
}
