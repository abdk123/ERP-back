using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Categories.Services
{
    public interface IMaterialCategoryDomainService : IDomainService
     {
        IQueryable<MaterialCategory> Get();
        Task<IList<MaterialCategory>> GetAllAsync();
        Task<MaterialCategory> GetByIdAsync(long id);
        Task<MaterialCategory> CreateAsync(MaterialCategory materialCategory);
        Task<MaterialCategory> UpdateAsync(MaterialCategory materialCategory);
        Task DeleteAsync(long id);
    }
}

