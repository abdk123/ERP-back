using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IMaterialDomainService : IDomainService
     {
        IQueryable<Material> Get();
        Task<IList<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(long id);
        Task<Material> CreateAsync(Material material);
        Task<Material> UpdateAsync(Material material);
        Task DeleteAsync(long id);
    }
}

