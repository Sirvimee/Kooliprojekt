using GameHouse.Data;
using GameHouse.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> Get(int id)
        {
            return await _bookingRepository.Get(id);
        }

        public async Task<IList<Booking>> List()
        {
            return await _bookingRepository.List();
        }

        public async Task<List<SelectListItem>> GetRoomDropdownList()
        {
            return _bookingRepository.GetRoomDropdownList();
        }

        public List<SelectListItem> GetTimeDropdownList()
        {
            // List for the dropdown with placeholder

            List<SelectListItem> timeList = new List<SelectListItem>();
            timeList.Add(new SelectListItem { Text = "10:00 - 13:00", Value = "10:00 - 13:00" });
            timeList.Add(new SelectListItem { Text = "14:00 - 17:00", Value = "14:00 - 17:00" });
            timeList.Add(new SelectListItem { Text = "18:00 - 21:00", Value = "18:00 - 21:00" });
            return timeList;
        }

        //list 

        public async Task Save(Booking booking)
        {
            await _bookingRepository.Save(booking);
        }

        public async Task Update(Booking booking)
        {
            await _bookingRepository.Update(booking);
        }

        public async Task Delete(int? id)
        {
            await _bookingRepository.Delete(id);
        }
    }
}