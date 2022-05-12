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
    public interface IStreetAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<StreetDto>> GetAllAsync();
        Task<StreetDto> GetByIdAsync(long id);
        Task<CreateStreetDto> CreateAsync(CreateStreetDto street);
        Task<UpdateStreetDto> UpdateAsync(UpdateStreetDto street);
        Task DeleteAsync(long id);
    }
}

