using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IMaterialUnitDomainService : IDomainService
     {
        IQueryable<MaterialUnit> Get();
        Task<IList<MaterialUnit>> GetAllAsync();
        Task<MaterialUnit> GetByIdAsync(long id);
        Task<MaterialUnit> CreateAsync(MaterialUnit materialUnit);
        Task<MaterialUnit> UpdateAsync(MaterialUnit materialUnit);
        Task DeleteAsync(long id);
    }
}

