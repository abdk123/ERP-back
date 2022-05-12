using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Services
{
    public class WarehouseDomainService : IWarehouseDomainService
    {
        private readonly IRepository<Warehouse, long> _warehouseRepository;
        public WarehouseDomainService(IRepository<Warehouse, long> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public IQueryable<Warehouse> Get()
        {
            return _warehouseRepository.GetAll();
        }
        public async Task<IList<Warehouse>> GetAllAsync()
        {
            return await _warehouseRepository.GetAllListAsync();
        }
        public async Task<Warehouse> GetByIdAsync(long id)
        {
            return await _warehouseRepository.FirstOrDefaultAsync(id);
        }
        public async Task<Warehouse> CreateAsync(Warehouse warehouse)
        {
            return await _warehouseRepository.InsertAsync(warehouse);
        }
        public async Task<Warehouse> UpdateAsync(Warehouse warehouse)
        {
            return await _warehouseRepository.InsertOrUpdateAsync(warehouse);
        }
        public async Task DeleteAsync(long id)
        {
            var warehouse = await _warehouseRepository.FirstOrDefaultAsync(id);
            await _warehouseRepository.DeleteAsync(warehouse);
        }
    }
}

