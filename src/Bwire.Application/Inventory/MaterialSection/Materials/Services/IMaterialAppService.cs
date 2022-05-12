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
    public interface IMaterialAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialDto>> GetAllAsync();
        Task<MaterialDto> GetByIdAsync(long id);
        Task<CreateMaterialDto> CreateAsync(CreateMaterialDto material);
        Task<UpdateMaterialDto> UpdateAsync(UpdateMaterialDto material);
        Task DeleteAsync(long id);
    }
}

