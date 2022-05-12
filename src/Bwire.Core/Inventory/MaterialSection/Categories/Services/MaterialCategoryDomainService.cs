using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Categories.Services
{
    public class MaterialCategoryDomainService : IMaterialCategoryDomainService
    {
        private readonly IRepository<MaterialCategory, long> _materialCategoryRepository;
        public MaterialCategoryDomainService(IRepository<MaterialCategory, long> materialCategoryRepository)
        {
            _materialCategoryRepository = materialCategoryRepository;
        }
        public IQueryable<MaterialCategory> Get()
        {
            return _materialCategoryRepository.GetAll();
        }
        public async Task<IList<MaterialCategory>> GetAllAsync()
        {
            return await _materialCategoryRepository.GetAllListAsync();
        }
        public async Task<MaterialCategory> GetByIdAsync(long id)
        {
            return await _materialCategoryRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialCategory> CreateAsync(MaterialCategory materialCategory)
        {
            return await _materialCategoryRepository.InsertAsync(materialCategory);
        }
        public async Task<MaterialCategory> UpdateAsync(MaterialCategory materialCategory)
        {
            return await _materialCategoryRepository.InsertOrUpdateAsync(materialCategory);
        }
        public async Task DeleteAsync(long id)
        {
            var materialCategory = await _materialCategoryRepository.FirstOrDefaultAsync(id);
            await _materialCategoryRepository.DeleteAsync(materialCategory);
        }
    }
}

