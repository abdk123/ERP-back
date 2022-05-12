using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IAreaDomainService : IDomainService
     {
        IQueryable<Area> Get();
        Task<IList<Area>> GetAllAsync();
        Task<Area> GetByIdAsync(long id);
        Task<Area> CreateAsync(Area area);
        Task<Area> UpdateAsync(Area area);
        Task DeleteAsync(long id);
    }
}

