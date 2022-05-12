using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.MaterialSection.Materials.MaterialActions.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Services
{
    public interface IMaterialActionAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialActionDto>> GetAllAsync();
        Task<MaterialActionDto> GetByIdAsync(long id);
        Task<CreateMaterialActionDto> CreateAsync(CreateMaterialActionDto materialAction);
        Task<UpdateMaterialActionDto> UpdateAsync(UpdateMaterialActionDto materialAction);
        Task DeleteAsync(long id);
    }
}

