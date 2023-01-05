using Microsoft.EntityFrameworkCore;

namespace GameHouse.Data
{
    public interface IRoomRepository
    {
        Task<Room> Get(int id);
        Task<IList<Room>> List();
        Task Save(Room room);
        Task Update(Room room);
        Task Delete(int? id);
    }
}
