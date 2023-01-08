using GameHouse.Data;
using GameHouse.Repositories;

namespace GameHouse.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> Get(int id)
        {
            return await _bookingRepository.Get(id);
        }

        public async Task<IList<Booking>> List()
        {
            return await _bookingRepository.List();
        }

        public async Task Save(Booking booking)
        {
            await _bookingRepository.Save(booking);
        }

        public async Task Delete(int? id)
        {
            await _bookingRepository.Delete(id);
        }
    }
}
