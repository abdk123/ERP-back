using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class StreetDomainService : IStreetDomainService
    {
        private readonly IRepository<Street, long> _streetRepository;
        public StreetDomainService(IRepository<Street, long> streetRepository)
        {
            _streetRepository = streetRepository;
        }
        public IQueryable<Street> Get()
        {
            return _streetRepository.GetAll();
        }
        public async Task<IList<Street>> GetAllAsync()
        {
            return await _streetRepository.GetAllListAsync();
        }
        public async Task<Street> GetByIdAsync(long id)
        {
            return await _streetRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Street> CreateAsync(Street street)
        {
            return await _streetRepository.InsertAsync(street);
        }
        public async Task<Street> UpdateAsync(Street street)
        {
            return await _streetRepository.InsertOrUpdateAsync(street);
        }
        public async Task DeleteAsync(long id)
        {
            var street = await _streetRepository.FirstOrDefaultAsync(id);
            await _streetRepository.DeleteAsync(street);
        }
    }
}

