using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class CityDomainService : ICityDomainService
    {
        private readonly IRepository<City, long> _cityRepository;
        public CityDomainService(IRepository<City, long> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IQueryable<City> Get()
        {
            return _cityRepository.GetAll();
        }
        public async Task<IList<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllListAsync();
        }
        public async Task<City> GetByIdAsync(long id)
        {
            return await _cityRepository.FirstOrDefaultAsync(id);
        }
        public async Task<City> CreateAsync(City city)
        {
            return await _cityRepository.InsertAsync(city);
        }
        public async Task<City> UpdateAsync(City city)
        {
            return await _cityRepository.InsertOrUpdateAsync(city);
        }
        public async Task DeleteAsync(long id)
        {
            var city = await _cityRepository.FirstOrDefaultAsync(id);
            await _cityRepository.DeleteAsync(city);
        }
    }
}

