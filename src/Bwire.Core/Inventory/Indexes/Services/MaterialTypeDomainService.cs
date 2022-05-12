using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class MaterialTypeDomainService : IMaterialTypeDomainService
    {
        private readonly IRepository<MaterialType, long> _materialTypeRepository;
        public MaterialTypeDomainService(IRepository<MaterialType, long> materialTypeRepository)
        {
            _materialTypeRepository = materialTypeRepository;
        }
        public IQueryable<MaterialType> Get()
        {
            return _materialTypeRepository.GetAll();
        }
        public async Task<IList<MaterialType>> GetAllAsync()
        {
            return await _materialTypeRepository.GetAllListAsync();
        }
        public async Task<MaterialType> GetByIdAsync(long id)
        {
            return await _materialTypeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialType> CreateAsync(MaterialType materialType)
        {
            return await _materialTypeRepository.InsertAsync(materialType);
        }
        public async Task<MaterialType> UpdateAsync(MaterialType materialType)
        {
            return await _materialTypeRepository.InsertOrUpdateAsync(materialType);
        }
        public async Task DeleteAsync(long id)
        {
            var materialType = await _materialTypeRepository.FirstOrDefaultAsync(id);
            await _materialTypeRepository.DeleteAsync(materialType);
        }
    }
}

