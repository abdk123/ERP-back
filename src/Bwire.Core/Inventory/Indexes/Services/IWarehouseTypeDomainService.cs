using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IWarehouseTypeDomainService : IDomainService
     {
        IQueryable<WarehouseType> Get();
        Task<IList<WarehouseType>> GetAllAsync();
        Task<WarehouseType> GetByIdAsync(long id);
        Task<WarehouseType> CreateAsync(WarehouseType warehouseType);
        Task<WarehouseType> UpdateAsync(WarehouseType warehouseType);
        Task DeleteAsync(long id);
    }
}

