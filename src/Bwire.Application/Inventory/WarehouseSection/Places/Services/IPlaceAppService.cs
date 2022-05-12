using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.WarehouseSection.Places.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.WarehouseSection.Places.Services
{
    public interface IPlaceAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<PlaceDto>> GetAllAsync();
        Task<PlaceDto> GetByIdAsync(long id);
        Task<CreatePlaceDto> CreateAsync(CreatePlaceDto place);
        Task<UpdatePlaceDto> UpdateAsync(UpdatePlaceDto place);
        Task DeleteAsync(long id);
    }
}

