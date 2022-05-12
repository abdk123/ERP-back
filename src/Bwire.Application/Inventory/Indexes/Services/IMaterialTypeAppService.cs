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
    public interface IMaterialTypeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialTypeDto>> GetAllAsync();
        Task<MaterialTypeDto> GetByIdAsync(long id);
        Task<CreateMaterialTypeDto> CreateAsync(CreateMaterialTypeDto materialType);
        Task<UpdateMaterialTypeDto> UpdateAsync(UpdateMaterialTypeDto materialType);
        Task DeleteAsync(long id);
    }
}

