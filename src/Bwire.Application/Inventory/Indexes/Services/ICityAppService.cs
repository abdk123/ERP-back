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
    public interface ICityAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(long id);
        Task<CreateCityDto> CreateAsync(CreateCityDto city);
        Task<UpdateCityDto> UpdateAsync(UpdateCityDto city);
        Task DeleteAsync(long id);
    }
}

