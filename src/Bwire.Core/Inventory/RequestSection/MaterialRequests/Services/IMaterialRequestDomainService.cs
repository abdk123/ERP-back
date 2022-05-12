using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public interface IMaterialRequestDomainService : IDomainService
     {
        IQueryable<MaterialRequest> Get();
        Task<IList<MaterialRequest>> GetAllAsync();
        Task<MaterialRequest> GetByIdAsync(long id);
        Task<MaterialRequest> CreateAsync(MaterialRequest materialRequest);
        Task<MaterialRequest> UpdateAsync(MaterialRequest materialRequest);
        Task DeleteAsync(long id);
    }
}

