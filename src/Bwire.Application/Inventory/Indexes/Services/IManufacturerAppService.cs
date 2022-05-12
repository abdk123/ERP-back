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
    public interface IManufacturerAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<ManufacturerDto>> GetAllAsync();
        Task<ManufacturerDto> GetByIdAsync(long id);
        Task<CreateManufacturerDto> CreateAsync(CreateManufacturerDto manufacturer);
        Task<UpdateManufacturerDto> UpdateAsync(UpdateManufacturerDto manufacturer);
        Task DeleteAsync(long id);
    }
}

