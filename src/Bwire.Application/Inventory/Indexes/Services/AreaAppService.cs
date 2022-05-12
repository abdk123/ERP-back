using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.Indexes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.Indexes.Services
{
    public class AreaAppService : BwireAppServiceBase, IAreaAppService
    {
        private readonly IAreaDomainService _areaDomainService;
        public AreaAppService(IAreaDomainService areaDomainService)
        {
            _areaDomainService = areaDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _areaDomainService.Get().ToList();
            IEnumerable<AreaDto> data = ObjectMapper.Map<List<AreaDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<AreaDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformGrouping(data, dm.Group);
            }
            
            var count = data.Count();
            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }
            
            if (dm.Take != 0)
            {
                data = operations.PerformSkip(data, dm.Take);
            }
            
            return new ReadGrudDto() { result = data,count = 0, groupDs = groupDs };
        }
        public async Task<IList<AreaDto>> GetAllAsync()
        {
            var list = await _areaDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<AreaDto>>(list);
        }
        public async Task<AreaDto> GetByIdAsync(long id)
        {
            var area = await _areaDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<AreaDto>(area);
        }
        public async Task<CreateAreaDto> CreateAsync(CreateAreaDto areaDto)
        {
            var area = ObjectMapper.Map<Area>(areaDto);
            var createdArea = await _areaDomainService.CreateAsync(area);
            return ObjectMapper.Map<CreateAreaDto>(createdArea);
        }
        public async Task<UpdateAreaDto> UpdateAsync(UpdateAreaDto areaDto)
        {
            var area = ObjectMapper.Map<Area>(areaDto);
            var updatedArea = await _areaDomainService.UpdateAsync(area);
            return ObjectMapper.Map<UpdateAreaDto>(updatedArea);
        }
        public async Task DeleteAsync(long id)
        {
            await _areaDomainService.DeleteAsync(id);
        }
    }
}

