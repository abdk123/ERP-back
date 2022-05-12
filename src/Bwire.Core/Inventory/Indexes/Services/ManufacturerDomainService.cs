using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class ManufacturerDomainService : IManufacturerDomainService
    {
        private readonly IRepository<Manufacturer, long> _manufacturerRepository;
        public ManufacturerDomainService(IRepository<Manufacturer, long> manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }
        public IQueryable<Manufacturer> Get()
        {
            return _manufacturerRepository.GetAll();
        }
        public async Task<IList<Manufacturer>> GetAllAsync()
        {
            return await _manufacturerRepository.GetAllListAsync();
        }
        public async Task<Manufacturer> GetByIdAsync(long id)
        {
            return await _manufacturerRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Manufacturer> CreateAsync(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.InsertAsync(manufacturer);
        }
        public async Task<Manufacturer> UpdateAsync(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.InsertOrUpdateAsync(manufacturer);
        }
        public async Task DeleteAsync(long id)
        {
            var manufacturer = await _manufacturerRepository.FirstOrDefaultAsync(id);
            await _manufacturerRepository.DeleteAsync(manufacturer);
        }
    }
}

