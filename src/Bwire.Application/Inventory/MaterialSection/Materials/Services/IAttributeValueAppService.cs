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
    public interface IAttributeValueAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<AttributeValueDto>> GetAllAsync();
        Task<AttributeValueDto> GetByIdAsync(long id);
        Task<CreateAttributeValueDto> CreateAsync(CreateAttributeValueDto attributeValue);
        Task<UpdateAttributeValueDto> UpdateAsync(UpdateAttributeValueDto attributeValue);
        Task DeleteAsync(long id);
    }
}

