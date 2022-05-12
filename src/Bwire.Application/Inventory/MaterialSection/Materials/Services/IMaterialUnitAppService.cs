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
    public interface IMaterialUnitAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialUnitDto>> GetAllAsync();
        Task<MaterialUnitDto> GetByIdAsync(long id);
        Task<CreateMaterialUnitDto> CreateAsync(CreateMaterialUnitDto materialUnit);
        Task<UpdateMaterialUnitDto> UpdateAsync(UpdateMaterialUnitDto materialUnit);
        Task DeleteAsync(long id);
    }
}

