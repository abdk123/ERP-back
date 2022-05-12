using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IUnitDomainService : IDomainService
     {
        IQueryable<Unit> Get();
        Task<IList<Unit>> GetAllAsync();
        Task<Unit> GetByIdAsync(long id);
        Task<Unit> CreateAsync(Unit unit);
        Task<Unit> UpdateAsync(Unit unit);
        Task DeleteAsync(long id);
    }
}

