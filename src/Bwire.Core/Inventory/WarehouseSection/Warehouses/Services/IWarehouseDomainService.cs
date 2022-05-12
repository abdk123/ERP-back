using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Services
{
    public interface IWarehouseDomainService : IDomainService
     {
        IQueryable<Warehouse> Get();
        Task<IList<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(long id);
        Task<Warehouse> CreateAsync(Warehouse warehouse);
        Task<Warehouse> UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(long id);
    }
}

