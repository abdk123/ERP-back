using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.MaterialSection.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.MaterialSection.Categories.Services
{
    public interface IMaterialCategoryAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<MaterialCategoryDto>> GetAllAsync();
        Task<MaterialCategoryDto> GetByIdAsync(long id);
        Task<CreateMaterialCategoryDto> CreateAsync(CreateMaterialCategoryDto materialCategory);
        Task<UpdateMaterialCategoryDto> UpdateAsync(UpdateMaterialCategoryDto materialCategory);
        Task DeleteAsync(long id);
    }
}

