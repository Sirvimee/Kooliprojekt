using GameHouse.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> Get(int id)
        {
            var booking = await _context.Booking
                .Include(b => b.Name)
                .FirstOrDefaultAsync(m => m.Id == id);

            return (booking);

        }

        public async Task<IList<Booking>> List()
        {
            return await _context.Booking.ToListAsync();
        }

        public List<SelectListItem> GetRoomDropdownList()
        {
            return _context.Room
            .Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            })
            .ToList();
        }

        public async Task Save(Booking booking)
        {
            if (booking.Id == 0)
            {
                await _context.AddAsync(booking);
            }
            else
            {
                _context.Update(booking);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(Booking booking)
        {
            if (booking.Id != 0)
            {
                _context.Update(booking);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return;
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}

