using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.WarehouseSection.Categories.Services
{
    public interface IWarehouseCategoryDomainService : IDomainService
     {
        IQueryable<WarehouseCategory> Get();
        Task<IList<WarehouseCategory>> GetAllAsync();
        Task<WarehouseCategory> GetByIdAsync(long id);
        Task<WarehouseCategory> CreateAsync(WarehouseCategory warehouseCategory);
        Task<WarehouseCategory> UpdateAsync(WarehouseCategory warehouseCategory);
        Task DeleteAsync(long id);
    }
}

