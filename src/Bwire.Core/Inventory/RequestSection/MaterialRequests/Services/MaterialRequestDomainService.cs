using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public class MaterialRequestDomainService : IMaterialRequestDomainService
    {
        private readonly IRepository<MaterialRequest, long> _materialRequestRepository;
        public MaterialRequestDomainService(IRepository<MaterialRequest, long> materialRequestRepository)
        {
            _materialRequestRepository = materialRequestRepository;
        }
        public IQueryable<MaterialRequest> Get()
        {
            return _materialRequestRepository.GetAll();
        }
        public async Task<IList<MaterialRequest>> GetAllAsync()
        {
            return await _materialRequestRepository.GetAllListAsync();
        }
        public async Task<MaterialRequest> GetByIdAsync(long id)
        {
            return await _materialRequestRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialRequest> CreateAsync(MaterialRequest materialRequest)
        {
            return await _materialRequestRepository.InsertAsync(materialRequest);
        }
        public async Task<MaterialRequest> UpdateAsync(MaterialRequest materialRequest)
        {
            return await _materialRequestRepository.InsertOrUpdateAsync(materialRequest);
        }
        public async Task DeleteAsync(long id)
        {
            var materialRequest = await _materialRequestRepository.FirstOrDefaultAsync(id);
            await _materialRequestRepository.DeleteAsync(materialRequest);
        }
    }
}

