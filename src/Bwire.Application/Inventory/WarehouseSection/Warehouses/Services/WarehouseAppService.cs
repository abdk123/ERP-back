using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.WarehouseSection.Warehouses.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Services
{
    public class WarehouseAppService : BwireAppServiceBase, IWarehouseAppService
    {
        private readonly IWarehouseDomainService _warehouseDomainService;
        public WarehouseAppService(IWarehouseDomainService warehouseDomainService)
        {
            _warehouseDomainService = warehouseDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _warehouseDomainService.Get().ToList();
            IEnumerable<WarehouseDto> data = ObjectMapper.Map<List<WarehouseDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<WarehouseDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformGrouping(data, dm.Group);
            }
            
            var count = data.Count();
            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }
            
            if (dm.Take != 0)
            {
                data = operations.PerformSkip(data, dm.Take);
            }
            
            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };
        }
        public async Task<IList<WarehouseDto>> GetAllAsync()
        {
            var list = await _warehouseDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<WarehouseDto>>(list);
        }
        public async Task<WarehouseDto> GetByIdAsync(long id)
        {
            var warehouse = await _warehouseDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<WarehouseDto>(warehouse);
        }
        public async Task<CreateWarehouseDto> CreateAsync(CreateWarehouseDto warehouseDto)
        {
            var warehouse = ObjectMapper.Map<Warehouse>(warehouseDto);
            var createdWarehouse = await _warehouseDomainService.CreateAsync(warehouse);
            return ObjectMapper.Map<CreateWarehouseDto>(createdWarehouse);
        }
        public async Task<UpdateWarehouseDto> UpdateAsync(UpdateWarehouseDto warehouseDto)
        {
            var warehouse = ObjectMapper.Map<Warehouse>(warehouseDto);
            var updatedWarehouse = await _warehouseDomainService.UpdateAsync(warehouse);
            return ObjectMapper.Map<UpdateWarehouseDto>(updatedWarehouse);
        }
        public async Task DeleteAsync(long id)
        {
            await _warehouseDomainService.DeleteAsync(id);
        }
    }
}

