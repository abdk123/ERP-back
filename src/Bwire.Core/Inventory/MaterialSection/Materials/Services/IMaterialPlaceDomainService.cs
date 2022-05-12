using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IMaterialPlaceDomainService : IDomainService
     {
        IQueryable<MaterialPlace> Get();
        Task<IList<MaterialPlace>> GetAllAsync();
        Task<MaterialPlace> GetByIdAsync(long id);
        Task<MaterialPlace> CreateAsync(MaterialPlace materialPlace);
        Task<MaterialPlace> UpdateAsync(MaterialPlace materialPlace);
        Task DeleteAsync(long id);
    }
}

