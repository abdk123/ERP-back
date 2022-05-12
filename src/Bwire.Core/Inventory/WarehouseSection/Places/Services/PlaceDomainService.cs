using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Bwire.Inventory.WarehouseSection.Places;

namespace Bwire.Inventory.WarehouseSection.Places.Services
{
    public class PlaceDomainService : IPlaceDomainService
    {
        private readonly IRepository<Place, long> _placeRepository;
        public PlaceDomainService(IRepository<Place, long> placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public IQueryable<Place> Get()
        {
            return _placeRepository.GetAll();
        }
        public async Task<IList<Place>> GetAllAsync()
        {
            return await _placeRepository.GetAllListAsync();
        }
        public async Task<Place> GetByIdAsync(long id)
        {
            return await _placeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Place> CreateAsync(Place place)
        {
            return await _placeRepository.InsertAsync(place);
        }
        public async Task<Place> UpdateAsync(Place place)
        {
            return await _placeRepository.InsertOrUpdateAsync(place);
        }
        public async Task DeleteAsync(long id)
        {
            var place = await _placeRepository.FirstOrDefaultAsync(id);
            await _placeRepository.DeleteAsync(place);
        }
    }
}

