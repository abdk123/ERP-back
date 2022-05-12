using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IManufacturerDomainService : IDomainService
     {
        IQueryable<Manufacturer> Get();
        Task<IList<Manufacturer>> GetAllAsync();
        Task<Manufacturer> GetByIdAsync(long id);
        Task<Manufacturer> CreateAsync(Manufacturer manufacturer);
        Task<Manufacturer> UpdateAsync(Manufacturer manufacturer);
        Task DeleteAsync(long id);
    }
}

