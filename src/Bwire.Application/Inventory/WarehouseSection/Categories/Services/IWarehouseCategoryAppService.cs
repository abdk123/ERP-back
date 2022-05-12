using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.WarehouseSection.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.WarehouseSection.Categories.Services
{
    public interface IWarehouseCategoryAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<WarehouseCategoryDto>> GetAllAsync();
        Task<WarehouseCategoryDto> GetByIdAsync(long id);
        Task<CreateWarehouseCategoryDto> CreateAsync(CreateWarehouseCategoryDto warehouseCategory);
        Task<UpdateWarehouseCategoryDto> UpdateAsync(UpdateWarehouseCategoryDto warehouseCategory);
        Task DeleteAsync(long id);
    }
}

