using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.MaterialSection.Materials.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public interface IMaterialQuantityAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialQuantityDto>> GetAllAsync();
        Task<MaterialQuantityDto> GetByIdAsync(long id);
        Task<CreateMaterialQuantityDto> CreateAsync(CreateMaterialQuantityDto materialQuantity);
        Task<UpdateMaterialQuantityDto> UpdateAsync(UpdateMaterialQuantityDto materialQuantity);
        Task DeleteAsync(long id);
    }
}

