using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameHouse.Data;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameHouse.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public GalleriesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Galleries
        public async Task<IActionResult> Index(int nameId)
        {
            List<Gallery> list = await (from callItem in _context.Gallery
                                        where callItem.NameId == nameId
                                        select new Gallery
                                        {
                                            Id = callItem.Id,
                                            ImageName = callItem.ImageName,
                                            NameId = nameId
                                        }).ToListAsync();

            ViewBag.NameId = nameId;
            return View(list);
        }

        // GET: Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gallery == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .Include(g => g.Name)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Galleries/Create
        public IActionResult Create(int nameId)
        {

            Gallery gallery = new Gallery
            {
                NameId = nameId
            };
            //ViewData["NameId"] = new SelectList(_context.Room, "Id", "Name");
            return View(gallery);
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameId,ImageFile")] Gallery gallery, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (gallery.Id == 0)
                {

                    //Save image to wwwroot/image
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(gallery.ImageFile.FileName);
                    string extension = Path.GetExtension(gallery.ImageFile.FileName);
                    gallery.ImageName = fileName = fileName + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await gallery.ImageFile.CopyToAsync(fileStream);
                    }
                    _context.Add(gallery);
                }
                else
                {
                    _context.Update(gallery);

                }

                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                //_context.Add(gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NameId"] = new SelectList(_context.Room, "Id", "Id", gallery.NameId);
            return View(gallery);
        }

        // GET: Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gallery == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            ViewData["NameId"] = new SelectList(_context.Room, "Id", "Id", gallery.NameId);
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NameId,ImageFile")] Gallery gallery)
        {
            if (id != gallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NameId"] = new SelectList(_context.Room, "Id", "Id", gallery.NameId);
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gallery == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .Include(g => g.Name)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gallery == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gallery'  is null.");
            }
            var gallery = await _context.Gallery.FindAsync(id);
            if (gallery != null)
            {
                _context.Gallery.Remove(gallery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
          return _context.Gallery.Any(e => e.Id == id);
        }
    }
}
