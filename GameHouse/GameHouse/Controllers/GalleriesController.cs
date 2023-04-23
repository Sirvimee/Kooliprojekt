using Microsoft.AspNetCore.Mvc;
using GameHouse.Data;
using GameHouse.Services;


namespace GameHouse.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly IGalleriesService _galleriesService;
        private readonly IWebHostEnvironment _environment;
        private readonly IRoomService _roomService;

        public GalleriesController(IGalleriesService galleriesService, IRoomService roomService, IWebHostEnvironment environment)
        {
            _galleriesService = galleriesService;
            _environment = environment;
            _roomService = roomService;
        }

        // GET: Galleries
        public async Task<IActionResult> Index(int roomId)
        {
            List<Gallery> list = await _galleriesService.Get(roomId);

            ViewBag.RoomId = roomId;
            return View(list);
        }

        // GET: Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _galleriesService.GetById(id.Value);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Galleries/Create
        public IActionResult Create(int roomId)
        {

            Gallery gallery = new Gallery
            {
                RoomId = roomId
            };
            return View(gallery);
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,ImageFile")] Gallery gallery, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (gallery.Id == 0)
                {

                    //Save image to wwwroot/image
                    string wwwRootPath = _environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(gallery.ImageFile.FileName);
                    string extension = Path.GetExtension(gallery.ImageFile.FileName);
                    gallery.ImageName = fileName = fileName + "-" + DateTime.Now.ToString("yyyy-MM-dd") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await gallery.ImageFile.CopyToAsync(fileStream);
                    }

                    await _galleriesService.Save(gallery);
                }
                else
                {
                   await _galleriesService.Update(gallery);

                }

                return RedirectToAction(nameof(AdminRooms));
            }
            // ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", gallery.RoomId);
            return RedirectToAction(nameof(AdminRooms));
        }

        // GET: Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _galleriesService.GetById(id.Value);
            if (gallery == null)
            {
                return NotFound();
            }
            //ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", gallery.RoomId);
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,ImageFile")] Gallery gallery)
        {
            if (id != gallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _galleriesService.Update(gallery);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", gallery.RoomId);
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _galleriesService.GetById(id.Value);
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

            // delete image file
            var gallery = await _galleriesService.GetById(id);
            string wwwRootPath = _environment.WebRootPath;
            string fileName = gallery.ImageName;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _galleriesService.Delete(id);

            return RedirectToAction(nameof(AdminRooms));
        }

        public async Task<IActionResult> AdminRooms()
        {
            var result = await _roomService.List();
            return View(result);
        }

    }
}
