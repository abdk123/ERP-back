using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.RequestSection.MaterialRequests.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public interface IMaterialRequestAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialRequestDto>> GetAllAsync();
        Task<MaterialRequestDto> GetByIdAsync(long id);
        Task<CreateMaterialRequestDto> CreateAsync(CreateMaterialRequestDto materialRequest);
        Task<UpdateMaterialRequestDto> UpdateAsync(UpdateMaterialRequestDto materialRequest);
        Task DeleteAsync(long id);
    }
}

