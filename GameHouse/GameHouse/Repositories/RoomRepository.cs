using GameHouse.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GameHouse.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomContext _context;

        public RoomRepository(RoomContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Room.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _context.Room.Find(id);
        }

        public void AddRoom(Room room)
        {
            _context.Room.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Room.Find(id);
            _context.Room.Remove(room);
            _context.SaveChanges();
        }
    }
}

