using GameHouse.Data;
using GameHouse.Repositories;

namespace GameHouse.Services
{
    public interface IGalleriesService
    {
        Task<List<Gallery>> Get(int roomId);
        Task<Gallery> GetById(int id);
        Task Save(Gallery gallery);
        Task Update(Gallery gallery);
        Task Delete(int? id);
    }
}