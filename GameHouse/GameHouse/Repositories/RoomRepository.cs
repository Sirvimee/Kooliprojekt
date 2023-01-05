using GameHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public class RoomRepository
    {
        private readonly RoomContext _context;

        public RoomRepository(RoomContext context)
        {
            _context = context;
        }

        public async Task<Room> Get(int id)
        {
            return await _context.Room.FirstOrDefaultAsync();
        }

        public async Task<IList<Room>> List()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task Save(Room room)
        {
            if (room.Id != 0)
            {
                _context.Add(room);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return;
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

    }
}
