using GameHouse.Data;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> Get(int id);
        Task<IList<Booking>> List();
        Task Save(Booking booking);
        Task Update(Booking booking);
        Task Delete(int? id);
    }
}
