using GameHouse.Data;

namespace GameHouse.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Booking.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Booking.Find(id);
        }

        public void AddBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Booking.Update(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Booking.Find(id);
            _context.Booking.Remove(booking);
            _context.SaveChanges();
        }
    }
}

