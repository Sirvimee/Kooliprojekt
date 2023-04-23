using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

namespace GameHouse.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingsController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var result = await _bookingService.List();
            return View(result);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _bookingService.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()

        {
            var rooms = await _bookingService.GetRoomDropdownList();
            ViewBag.Rooms = rooms;

            var times = _bookingService.GetTimeDropdownList();
            ViewBag.Times = times;

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.Save(booking);
                return RedirectToAction(nameof(Index));
            }

            //var rooms = await _bookingService.GetRoomDropdownList();

            //ViewBag.Rooms = rooms;

            return View();
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _bookingService.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            var rooms = await _bookingService.GetRoomDropdownList();

            ViewBag.Rooms = rooms;
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bookingService.Update(booking);
                return RedirectToAction(nameof(Index));
            }

            var rooms = await _bookingService.GetRoomDropdownList();

            ViewBag.Rooms = rooms;
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _bookingService.Get(id.Value);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool BookingExists(int id)
        //{
        //    return _context.Booking.Any(e => e.Id == id);
        //}
    }
}
