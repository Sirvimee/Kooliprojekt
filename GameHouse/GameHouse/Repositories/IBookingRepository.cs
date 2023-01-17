using GameHouse.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> Get(int id);
        Task<IList<Booking>> List();
        List<SelectListItem> GetRoomDropdownList();
        Task Save(Booking booking);
        Task Update(Booking booking);
        Task Delete(int? id);
    }
}
