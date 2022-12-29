using GameHouse.Data;
using GameHouse.Repositories;

namespace GameHouse.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository _bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public void AddBooking(Booking booking)
        {
             _bookingRepository.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(int id)
        {
             _bookingRepository.DeleteBooking(id);
        }

        public IEnumerable<Booking> GetAvailableBookingsForDate(DateTime date)
        {
            return _bookingRepository.GetAllBookings()
                .Where(b => b.Date == date && b.Time == "Available");
        }

        public void MakeBooking(Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }

        public void CancelBooking(int id)
        {
             _bookingRepository.DeleteBooking(id);
        }
    }
}
