using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public class MaterialRequestDetailDomainService : IMaterialRequestDetailDomainService
    {
        private readonly IRepository<MaterialRequestDetail, long> _materialRequestDetailRepository;
        public MaterialRequestDetailDomainService(IRepository<MaterialRequestDetail, long> materialRequestDetailRepository)
        {
            _materialRequestDetailRepository = materialRequestDetailRepository;
        }
        public IQueryable<MaterialRequestDetail> Get()
        {
            return _materialRequestDetailRepository.GetAll();
        }
        public async Task<IList<MaterialRequestDetail>> GetAllAsync()
        {
            return await _materialRequestDetailRepository.GetAllListAsync();
        }
        public async Task<MaterialRequestDetail> GetByIdAsync(long id)
        {
            return await _materialRequestDetailRepository.FirstOrDefaultAsync(id);
        }
        public async Task<MaterialRequestDetail> CreateAsync(MaterialRequestDetail materialRequestDetail)
        {
            return await _materialRequestDetailRepository.InsertAsync(materialRequestDetail);
        }
        public async Task<MaterialRequestDetail> UpdateAsync(MaterialRequestDetail materialRequestDetail)
        {
            return await _materialRequestDetailRepository.InsertOrUpdateAsync(materialRequestDetail);
        }
        public async Task DeleteAsync(long id)
        {
            var materialRequestDetail = await _materialRequestDetailRepository.FirstOrDefaultAsync(id);
            await _materialRequestDetailRepository.DeleteAsync(materialRequestDetail);
        }
    }
}

