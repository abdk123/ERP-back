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
    public interface IAreaAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<AreaDto>> GetAllAsync();
        Task<AreaDto> GetByIdAsync(long id);
        Task<CreateAreaDto> CreateAsync(CreateAreaDto area);
        Task<UpdateAreaDto> UpdateAsync(UpdateAreaDto area);
        Task DeleteAsync(long id);
    }
}

