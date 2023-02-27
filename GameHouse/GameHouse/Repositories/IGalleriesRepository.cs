using GameHouse.Data;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Repositories
{
    public interface IGalleriesRepository
    {
        Task<List<Gallery>> Get(int roomId);
        Task<Gallery> GetById(int id);
        Task Save(Gallery gallery);
        Task Update(Gallery gallery);
        Task Delete(int? id);
    }
}
