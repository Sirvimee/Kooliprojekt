using GameHouse.Data;

namespace GameHouse.Services
{
    public class RoomService : IRoomService
    {
        private readonly RoomRepository _roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public void AddRoom(Room room)
        {
            _roomRepository.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
        }
    }
}
