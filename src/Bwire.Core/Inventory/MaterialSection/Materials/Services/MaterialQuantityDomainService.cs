using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class MaterialQuantityDomainService : IMaterialQuantityDomainService
    {
        private readonly IRepository<MaterialQuantity, long> _materialQuantityRepository;
        public MaterialQuantityDomainService(IRepository<MaterialQuantity, long> materialQuantityRepository)
        {
            _materialQuantityRepository = materialQuantityRepository;
        }
        public IQueryable<MaterialQuantity> Get()
        {
            return _materialQuantityRepository.GetAll();
        }
        public async Task<IList<MaterialQuantity>> GetAllAsync()
        {
            return await _materialQuantityRepository.GetAllListAsync();
        }
        public async Task<MaterialQuantity> GetByIdAsync(long id)
        {
            return await _materialQuantityRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialQuantity> CreateAsync(MaterialQuantity materialQuantity)
        {
            return await _materialQuantityRepository.InsertAsync(materialQuantity);
        }
        public async Task<MaterialQuantity> UpdateAsync(MaterialQuantity materialQuantity)
        {
            return await _materialQuantityRepository.InsertOrUpdateAsync(materialQuantity);
        }
        public async Task DeleteAsync(long id)
        {
            var materialQuantity = await _materialQuantityRepository.FirstOrDefaultAsync(id);
            await _materialQuantityRepository.DeleteAsync(materialQuantity);
        }
    }
}

