using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public interface IMaterialRequestDetailDomainService : IDomainService
     {
        IQueryable<MaterialRequestDetail> Get();
        Task<IList<MaterialRequestDetail>> GetAllAsync();
        Task<MaterialRequestDetail> GetByIdAsync(long id);
        Task<MaterialRequestDetail> CreateAsync(MaterialRequestDetail materialRequestDetail);
        Task<MaterialRequestDetail> UpdateAsync(MaterialRequestDetail materialRequestDetail);
        Task DeleteAsync(long id);
    }
}

