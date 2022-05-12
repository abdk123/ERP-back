using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class CorrespondingMaterialDomainService : ICorrespondingMaterialDomainService
    {
        private readonly IRepository<CorrespondingMaterial, long> _correspondingMaterialRepository;
        public CorrespondingMaterialDomainService(IRepository<CorrespondingMaterial, long> correspondingMaterialRepository)
        {
            _correspondingMaterialRepository = correspondingMaterialRepository;
        }
        public IQueryable<CorrespondingMaterial> Get()
        {
            return _correspondingMaterialRepository.GetAll();
        }
        public async Task<IList<CorrespondingMaterial>> GetAllAsync()
        {
            return await _correspondingMaterialRepository.GetAllListAsync();
        }
        public async Task<CorrespondingMaterial> GetByIdAsync(long id)
        {
            return await _correspondingMaterialRepository.FirstOrDefaultAsync(id);
        }
        public async Task<CorrespondingMaterial> CreateAsync(CorrespondingMaterial correspondingMaterial)
        {
            return await _correspondingMaterialRepository.InsertAsync(correspondingMaterial);
        }
        public async Task<CorrespondingMaterial> UpdateAsync(CorrespondingMaterial correspondingMaterial)
        {
            return await _correspondingMaterialRepository.InsertOrUpdateAsync(correspondingMaterial);
        }
        public async Task DeleteAsync(long id)
        {
            var correspondingMaterial = await _correspondingMaterialRepository.FirstOrDefaultAsync(id);
            await _correspondingMaterialRepository.DeleteAsync(correspondingMaterial);
        }
    }
}

