using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.Indexes.Services
{
    public class WarehouseTypeAppService : BwireAppServiceBase, IWarehouseTypeAppService
    {
        private readonly IWarehouseTypeDomainService _warehouseTypeDomainService;
        public WarehouseTypeAppService(IWarehouseTypeDomainService warehouseTypeDomainService)
        {
            _warehouseTypeDomainService = warehouseTypeDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _warehouseTypeDomainService.Get().ToList();
            IEnumerable<WarehouseTypeDto> data = ObjectMapper.Map<List<WarehouseTypeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<WarehouseTypeDto>();
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
        public async Task<IList<WarehouseTypeDto>> GetAllAsync()
        {
            var list = await _warehouseTypeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<WarehouseTypeDto>>(list);
        }
        public async Task<WarehouseTypeDto> GetByIdAsync(long id)
        {
            var warehouseType = await _warehouseTypeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<WarehouseTypeDto>(warehouseType);
        }
        public async Task<CreateWarehouseTypeDto> CreateAsync(CreateWarehouseTypeDto warehouseTypeDto)
        {
            var warehouseType = ObjectMapper.Map<WarehouseType>(warehouseTypeDto);
            var createdWarehouseType = await _warehouseTypeDomainService.CreateAsync(warehouseType);
            return ObjectMapper.Map<CreateWarehouseTypeDto>(createdWarehouseType);
        }
        public async Task<UpdateWarehouseTypeDto> UpdateAsync(UpdateWarehouseTypeDto warehouseTypeDto)
        {
            var warehouseType = ObjectMapper.Map<WarehouseType>(warehouseTypeDto);
            var updatedWarehouseType = await _warehouseTypeDomainService.UpdateAsync(warehouseType);
            return ObjectMapper.Map<UpdateWarehouseTypeDto>(updatedWarehouseType);
        }
        public async Task DeleteAsync(long id)
        {
            await _warehouseTypeDomainService.DeleteAsync(id);
        }
    }
}

