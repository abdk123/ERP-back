using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class MaterialPlaceDomainService : IMaterialPlaceDomainService
    {
        private readonly IRepository<MaterialPlace, long> _materialPlaceRepository;
        public MaterialPlaceDomainService(IRepository<MaterialPlace, long> materialPlaceRepository)
        {
            _materialPlaceRepository = materialPlaceRepository;
        }
        public IQueryable<MaterialPlace> Get()
        {
            return _materialPlaceRepository.GetAll();
        }
        public async Task<IList<MaterialPlace>> GetAllAsync()
        {
            return await _materialPlaceRepository.GetAllListAsync();
        }
        public async Task<MaterialPlace> GetByIdAsync(long id)
        {
            return await _materialPlaceRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialPlace> CreateAsync(MaterialPlace materialPlace)
        {
            return await _materialPlaceRepository.InsertAsync(materialPlace);
        }
        public async Task<MaterialPlace> UpdateAsync(MaterialPlace materialPlace)
        {
            return await _materialPlaceRepository.InsertOrUpdateAsync(materialPlace);
        }
        public async Task DeleteAsync(long id)
        {
            var materialPlace = await _materialPlaceRepository.FirstOrDefaultAsync(id);
            await _materialPlaceRepository.DeleteAsync(materialPlace);
        }
    }
}

