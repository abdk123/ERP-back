using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.WarehouseSection.Categories.Services
{
    public class WarehouseCategoryDomainService : IWarehouseCategoryDomainService
    {
        private readonly IRepository<WarehouseCategory, long> _warehouseCategoryRepository;
        public WarehouseCategoryDomainService(IRepository<WarehouseCategory, long> warehouseCategoryRepository)
        {
            _warehouseCategoryRepository = warehouseCategoryRepository;
        }
        public IQueryable<WarehouseCategory> Get()
        {
            return _warehouseCategoryRepository.GetAll();
        }
        public async Task<IList<WarehouseCategory>> GetAllAsync()
        {
            return await _warehouseCategoryRepository.GetAllListAsync();
        }
        public async Task<WarehouseCategory> GetByIdAsync(long id)
        {
            return await _warehouseCategoryRepository.FirstOrDefaultAsync(id);
        }
        public async Task<WarehouseCategory> CreateAsync(WarehouseCategory warehouseCategory)
        {
            return await _warehouseCategoryRepository.InsertAsync(warehouseCategory);
        }
        public async Task<WarehouseCategory> UpdateAsync(WarehouseCategory warehouseCategory)
        {
            return await _warehouseCategoryRepository.InsertOrUpdateAsync(warehouseCategory);
        }
        public async Task DeleteAsync(long id)
        {
            var warehouseCategory = await _warehouseCategoryRepository.FirstOrDefaultAsync(id);
            await _warehouseCategoryRepository.DeleteAsync(warehouseCategory);
        }
    }
}

