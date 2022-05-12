using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.WarehouseSection.Warehouses.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Services
{
    public interface IWarehouseAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<WarehouseDto>> GetAllAsync();
        Task<WarehouseDto> GetByIdAsync(long id);
        Task<CreateWarehouseDto> CreateAsync(CreateWarehouseDto warehouse);
        Task<UpdateWarehouseDto> UpdateAsync(UpdateWarehouseDto warehouse);
        Task DeleteAsync(long id);
    }
}

