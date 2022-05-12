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
    public interface ICorrespondingMaterialAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<CorrespondingMaterialDto>> GetAllAsync();
        Task<CorrespondingMaterialDto> GetByIdAsync(long id);
        Task<CreateCorrespondingMaterialDto> CreateAsync(CreateCorrespondingMaterialDto correspondingMaterial);
        Task<UpdateCorrespondingMaterialDto> UpdateAsync(UpdateCorrespondingMaterialDto correspondingMaterial);
        Task DeleteAsync(long id);
    }
}

