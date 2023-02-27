using GameHouse.Data;
using GameHouse.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameHouse.Services
{
    public class GalleriesService : IGalleriesService
    {
        private readonly IGalleriesRepository _galleriesRepository;

        public GalleriesService(IGalleriesRepository galleriesRepository)
        {
            _galleriesRepository = galleriesRepository;
        }

        public async Task<List<Gallery>> Get(int roomId)
        {
            return await _galleriesRepository.Get(roomId);
        }

        public async Task<Gallery> GetById(int id)
        {
            return await _galleriesRepository.GetById(id);
        }

        public async Task Save(Gallery gallery)
        {
            await _galleriesRepository.Save(gallery);
        }

        public async Task Update(Gallery gallery)
        {
            await _galleriesRepository.Update(gallery);
        }

        public async Task Delete(int? id)
        {
            await _galleriesRepository.Delete(id);
        }
    }
}
