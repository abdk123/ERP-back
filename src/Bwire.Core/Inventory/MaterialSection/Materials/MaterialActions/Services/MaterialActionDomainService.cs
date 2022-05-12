using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Services
{
    public class MaterialActionDomainService : IMaterialActionDomainService
    {
        private readonly IRepository<MaterialAction, long> _materialActionRepository;
        public MaterialActionDomainService(IRepository<MaterialAction, long> materialActionRepository)
        {
            _materialActionRepository = materialActionRepository;
        }
        public IQueryable<MaterialAction> Get()
        {
            return _materialActionRepository.GetAll();
        }
        public async Task<IList<MaterialAction>> GetAllAsync()
        {
            return await _materialActionRepository.GetAllListAsync();
        }
        public async Task<MaterialAction> GetByIdAsync(long id)
        {
            return await _materialActionRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialAction> CreateAsync(MaterialAction materialAction)
        {
            return await _materialActionRepository.InsertAsync(materialAction);
        }
        public async Task<MaterialAction> UpdateAsync(MaterialAction materialAction)
        {
            return await _materialActionRepository.InsertOrUpdateAsync(materialAction);
        }
        public async Task DeleteAsync(long id)
        {
            var materialAction = await _materialActionRepository.FirstOrDefaultAsync(id);
            await _materialActionRepository.DeleteAsync(materialAction);
        }
    }
}

