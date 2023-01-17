using GameHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Get(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IList<Room>> List()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task Save(Room room)
        {
            if (room.Id == 0)
            {
                await _context.AddAsync(room);
            }
            else
            {
                _context.Update(room);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(Room room)
        {
            if (room.Id != 0)
            {
                _context.Update(room);
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
