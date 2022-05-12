using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.WarehouseSection.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.WarehouseSection.Categories.Services
{
    public class WarehouseCategoryAppService : BwireAppServiceBase, IWarehouseCategoryAppService
    {
        private readonly IWarehouseCategoryDomainService _warehouseCategoryDomainService;
        public WarehouseCategoryAppService(IWarehouseCategoryDomainService warehouseCategoryDomainService)
        {
            _warehouseCategoryDomainService = warehouseCategoryDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _warehouseCategoryDomainService.Get().ToList();
            IEnumerable<WarehouseCategoryDto> data = ObjectMapper.Map<List<WarehouseCategoryDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<WarehouseCategoryDto>();
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
        public async Task<IList<WarehouseCategoryDto>> GetAllAsync()
        {
            var list = await _warehouseCategoryDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<WarehouseCategoryDto>>(list);
        }
        public async Task<WarehouseCategoryDto> GetByIdAsync(long id)
        {
            var warehouseCategory = await _warehouseCategoryDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<WarehouseCategoryDto>(warehouseCategory);
        }
        public async Task<CreateWarehouseCategoryDto> CreateAsync(CreateWarehouseCategoryDto warehouseCategoryDto)
        {
            var warehouseCategory = ObjectMapper.Map<WarehouseCategory>(warehouseCategoryDto);
            var createdWarehouseCategory = await _warehouseCategoryDomainService.CreateAsync(warehouseCategory);
            return ObjectMapper.Map<CreateWarehouseCategoryDto>(createdWarehouseCategory);
        }
        public async Task<UpdateWarehouseCategoryDto> UpdateAsync(UpdateWarehouseCategoryDto warehouseCategoryDto)
        {
            var warehouseCategory = ObjectMapper.Map<WarehouseCategory>(warehouseCategoryDto);
            var updatedWarehouseCategory = await _warehouseCategoryDomainService.UpdateAsync(warehouseCategory);
            return ObjectMapper.Map<UpdateWarehouseCategoryDto>(updatedWarehouseCategory);
        }
        public async Task DeleteAsync(long id)
        {
            await _warehouseCategoryDomainService.DeleteAsync(id);
        }
    }
}

