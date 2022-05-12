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
    public interface IMaterialRequestDetailAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialRequestDetailDto>> GetAllAsync();
        Task<MaterialRequestDetailDto> GetByIdAsync(long id);
        Task<CreateMaterialRequestDetailDto> CreateAsync(CreateMaterialRequestDetailDto materialRequestDetail);
        Task<UpdateMaterialRequestDetailDto> UpdateAsync(UpdateMaterialRequestDetailDto materialRequestDetail);
        Task DeleteAsync(long id);
    }
}

