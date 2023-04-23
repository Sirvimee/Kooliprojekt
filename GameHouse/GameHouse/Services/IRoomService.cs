using GameHouse.Data;
using GameHouse.Repositories;

namespace GameHouse.Services
{
    public interface IRoomService
    {
        Task<Room> Get(int id);
        Task<IList<Room>> List();
        Task Save(Room model);
        Task Update(Room model);
        Task Delete(int? id);
    }
}
