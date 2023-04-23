using GameHouse.Data;
using GameHouse.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> Get(int id)
        {
            return await _roomRepository.Get(id);
        }

        public async Task<IList<Room>> List()
        {
            return await _roomRepository.List();
        }

        public async Task Save(Room room)
        {
            await _roomRepository.Save(room);
        }

        public async Task Update(Room room)
        {
            await _roomRepository.Update(room);
        }

        public async Task Delete(int? id)
        {
            await _roomRepository.Delete(id);
        }
    }
}
