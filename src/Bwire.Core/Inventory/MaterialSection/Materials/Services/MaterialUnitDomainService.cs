using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class MaterialUnitDomainService : IMaterialUnitDomainService
    {
        private readonly IRepository<MaterialUnit, long> _materialUnitRepository;
        public MaterialUnitDomainService(IRepository<MaterialUnit, long> materialUnitRepository)
        {
            _materialUnitRepository = materialUnitRepository;
        }
        public IQueryable<MaterialUnit> Get()
        {
            return _materialUnitRepository.GetAll();
        }
        public async Task<IList<MaterialUnit>> GetAllAsync()
        {
            return await _materialUnitRepository.GetAllListAsync();
        }
        public async Task<MaterialUnit> GetByIdAsync(long id)
        {
            return await _materialUnitRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialUnit> CreateAsync(MaterialUnit materialUnit)
        {
            return await _materialUnitRepository.InsertAsync(materialUnit);
        }
        public async Task<MaterialUnit> UpdateAsync(MaterialUnit materialUnit)
        {
            return await _materialUnitRepository.InsertOrUpdateAsync(materialUnit);
        }
        public async Task DeleteAsync(long id)
        {
            var materialUnit = await _materialUnitRepository.FirstOrDefaultAsync(id);
            await _materialUnitRepository.DeleteAsync(materialUnit);
        }
    }
}

