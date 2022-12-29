using GameHouse.Data;

namespace GameHouse.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        IEnumerable<Booking> GetAvailableBookingsForDate(DateTime date);
        void MakeBooking(Booking booking);
        void CancelBooking(int id);
    }
}
