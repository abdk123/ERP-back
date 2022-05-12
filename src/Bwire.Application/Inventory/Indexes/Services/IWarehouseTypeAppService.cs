using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.Indexes.Services
{
    public interface IWarehouseTypeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<WarehouseTypeDto>> GetAllAsync();
        Task<WarehouseTypeDto> GetByIdAsync(long id);
        Task<CreateWarehouseTypeDto> CreateAsync(CreateWarehouseTypeDto warehouseType);
        Task<UpdateWarehouseTypeDto> UpdateAsync(UpdateWarehouseTypeDto warehouseType);
        Task DeleteAsync(long id);
    }
}

