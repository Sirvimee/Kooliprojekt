using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace GameHouse.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RoomRepository(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
                //Save image to wwwroot/ image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(room.ImageFile.FileName);
                string extension = Path.GetExtension(room.ImageFile.FileName);
                room.Image = fileName = fileName + "-" + DateTime.Now.ToString("yyyy-MM-dd") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await room.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(room);

                await _context.SaveChangesAsync(); // save changes to database to generate the Room.Id

                //also add room to gallery
                Gallery gallery = new Gallery();
                gallery.ImageName = room.Image;
                gallery.RoomId = room.Id;

                _context.Add(gallery);

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
                if (room.ImageFile != null)
                {
                    //Save image to wwwroot/ image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(room.ImageFile.FileName);
                    string extension = Path.GetExtension(room.ImageFile.FileName);
                    room.Image = fileName = fileName + "-" + DateTime.Now.ToString("yyyy-MM-dd") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await room.ImageFile.CopyToAsync(fileStream);
                    }
                } 
                else
                {
                    room.Image = room.Image;
                }

                _context.Update(room);

                await _context.SaveChangesAsync(); // save changes to database to generate the Room.Id

                if (room.ImageFile != null)
                {
                    //also add room to gallery
                    Gallery gallery = new Gallery();
                    gallery.ImageName = room.Image;
                    gallery.RoomId = room.Id;

                    _context.Add(gallery);
                }

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
