using GameHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace GameHouse.Repositories
{
    public class GalleriesRepository : IGalleriesRepository
    {
        private readonly ApplicationDbContext _context;

        public GalleriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gallery>> Get(int roomId)
        {
            return await (from callItem in _context.Gallery
                         where callItem.RoomId == roomId
                         select new Gallery
                         {
                            Id = callItem.Id,
                            ImageName = callItem.ImageName,
                            RoomId = roomId,
                            Room = callItem.Room
                         }).ToListAsync();

            //return await _context.Gallery
               // .Where(g => g.RoomId == roomId)
               // .ToListAsync();

        }

        public async Task<Gallery> GetById(int id)
        {
            return await _context.Gallery.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task Save(Gallery gallery)
        {
            await _context.Gallery.AddAsync(gallery);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Gallery gallery)
        {
            _context.Gallery.Update(gallery);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var gallery = await _context.Gallery.FindAsync(id);
            
            if (gallery == null)
            {
                return;
            }

            _context.Gallery.Remove(gallery);
            await _context.SaveChangesAsync();
        }

    }
}