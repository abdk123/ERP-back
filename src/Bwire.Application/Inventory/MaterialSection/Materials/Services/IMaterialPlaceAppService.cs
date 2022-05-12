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
    public interface IMaterialPlaceAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialPlaceDto>> GetAllAsync();
        Task<MaterialPlaceDto> GetByIdAsync(long id);
        Task<CreateMaterialPlaceDto> CreateAsync(CreateMaterialPlaceDto materialPlace);
        Task<UpdateMaterialPlaceDto> UpdateAsync(UpdateMaterialPlaceDto materialPlace);
        Task DeleteAsync(long id);
    }
}

