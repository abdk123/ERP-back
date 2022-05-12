using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IMaterialQuantityDomainService : IDomainService
     {
        IQueryable<MaterialQuantity> Get();
        Task<IList<MaterialQuantity>> GetAllAsync();
        Task<MaterialQuantity> GetByIdAsync(long id);
        Task<MaterialQuantity> CreateAsync(MaterialQuantity materialQuantity);
        Task<MaterialQuantity> UpdateAsync(MaterialQuantity materialQuantity);
        Task DeleteAsync(long id);
    }
}

