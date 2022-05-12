using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Services
{
    public interface IMaterialActionDomainService : IDomainService
     {
        IQueryable<MaterialAction> Get();
        Task<IList<MaterialAction>> GetAllAsync();
        Task<MaterialAction> GetByIdAsync(long id);
        Task<MaterialAction> CreateAsync(MaterialAction materialAction);
        Task<MaterialAction> UpdateAsync(MaterialAction materialAction);
        Task DeleteAsync(long id);
    }
}

