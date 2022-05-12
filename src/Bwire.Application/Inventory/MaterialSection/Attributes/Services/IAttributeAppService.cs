using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.MaterialSection.Attributes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public interface IAttributeAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<AttributeDto>> GetAllAsync();
        Task<AttributeDto> GetByIdAsync(long id);
        Task<CreateAttributeDto> CreateAsync(CreateAttributeDto attribute);
        Task<UpdateAttributeDto> UpdateAsync(UpdateAttributeDto attribute);
        Task DeleteAsync(long id);
    }
}

