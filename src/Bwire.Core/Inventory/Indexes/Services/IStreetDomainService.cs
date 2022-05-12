using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IStreetDomainService : IDomainService
     {
        IQueryable<Street> Get();
        Task<IList<Street>> GetAllAsync();
        Task<Street> GetByIdAsync(long id);
        Task<Street> CreateAsync(Street street);
        Task<Street> UpdateAsync(Street street);
        Task DeleteAsync(long id);
    }
}

