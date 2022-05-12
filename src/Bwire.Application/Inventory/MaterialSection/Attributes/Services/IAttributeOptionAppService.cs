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
    public interface IAttributeOptionAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<AttributeOptionDto>> GetAllAsync();
        Task<AttributeOptionDto> GetByIdAsync(long id);
        Task<CreateAttributeOptionDto> CreateAsync(CreateAttributeOptionDto attributeOption);
        Task<UpdateAttributeOptionDto> UpdateAsync(UpdateAttributeOptionDto attributeOption);
        Task DeleteAsync(long id);
    }
}

