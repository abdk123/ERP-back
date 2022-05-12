using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IMaterialTypeDomainService : IDomainService
     {
        IQueryable<MaterialType> Get();
        Task<IList<MaterialType>> GetAllAsync();
        Task<MaterialType> GetByIdAsync(long id);
        Task<MaterialType> CreateAsync(MaterialType materialType);
        Task<MaterialType> UpdateAsync(MaterialType materialType);
        Task DeleteAsync(long id);
    }
}

