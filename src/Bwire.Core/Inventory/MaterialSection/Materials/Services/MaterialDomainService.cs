using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class MaterialDomainService : IMaterialDomainService
    {
        private readonly IRepository<Material, long> _materialRepository;
        public MaterialDomainService(IRepository<Material, long> materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public IQueryable<Material> Get()
        {
            return _materialRepository.GetAll();
        }
        public async Task<IList<Material>> GetAllAsync()
        {
            return await _materialRepository.GetAllListAsync();
        }
        public async Task<Material> GetByIdAsync(long id)
        {
            return await _materialRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Material> CreateAsync(Material material)
        {
            return await _materialRepository.InsertAsync(material);
        }
        public async Task<Material> UpdateAsync(Material material)
        {
            return await _materialRepository.InsertOrUpdateAsync(material);
        }
        public async Task DeleteAsync(long id)
        {
            var material = await _materialRepository.FirstOrDefaultAsync(id);
            await _materialRepository.DeleteAsync(material);
        }
    }
}

