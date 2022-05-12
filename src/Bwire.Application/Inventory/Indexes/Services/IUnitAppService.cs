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
    public interface IUnitAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<UnitDto>> GetAllAsync();
        Task<UnitDto> GetByIdAsync(long id);
        Task<CreateUnitDto> CreateAsync(CreateUnitDto unit);
        Task<UpdateUnitDto> UpdateAsync(UpdateUnitDto unit);
        Task DeleteAsync(long id);
    }
}

