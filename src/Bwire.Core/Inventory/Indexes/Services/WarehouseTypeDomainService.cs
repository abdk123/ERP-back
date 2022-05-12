using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Bwire.Inventory.Indexes.Services
{
    public class WarehouseTypeDomainService : IWarehouseTypeDomainService
    {
        private readonly IRepository<WarehouseType, long> _warehouseTypeRepository;
        public WarehouseTypeDomainService(IRepository<WarehouseType, long> warehouseTypeRepository)
        {
            _warehouseTypeRepository = warehouseTypeRepository;
        }
        public IQueryable<WarehouseType> Get()
        {
            return _warehouseTypeRepository.GetAll();
        }
        public async Task<IList<WarehouseType>> GetAllAsync()
        {
            return await _warehouseTypeRepository.GetAllListAsync();
        }
        public async Task<WarehouseType> GetByIdAsync(long id)
        {
            return await _warehouseTypeRepository.FirstOrDefaultAsync(id);
        }
        public async Task<WarehouseType> CreateAsync(WarehouseType warehouseType)
        {
            return await _warehouseTypeRepository.InsertAsync(warehouseType);
        }
        public async Task<WarehouseType> UpdateAsync(WarehouseType warehouseType)
        {
            return await _warehouseTypeRepository.InsertOrUpdateAsync(warehouseType);
        }
        public async Task DeleteAsync(long id)
        {
            var warehouseType = await _warehouseTypeRepository.FirstOrDefaultAsync(id);
            await _warehouseTypeRepository.DeleteAsync(warehouseType);
        }
    }
}

