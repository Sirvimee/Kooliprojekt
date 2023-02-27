using GameHouse.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameHouse.Services
{
    public interface IBookingService
    {
        Task<Booking> Get(int id);
        Task<IList<Booking>> List();
        Task<List<SelectListItem>> GetRoomDropdownList();
        Task Save(Booking booking);
        Task Update(Booking booking);
        Task Delete(int? id);
    }
}
