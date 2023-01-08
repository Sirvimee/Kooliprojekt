using GameHouse.Data;

namespace GameHouse.Services
{
    public interface IBookingService
    {
        Task<Booking> Get(int id);
        Task<IList<Booking>> List();
        Task Save(Booking booking);
        Task Delete(int? id);
    }
}
