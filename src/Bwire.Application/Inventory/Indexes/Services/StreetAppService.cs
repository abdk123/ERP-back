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
    public class StreetAppService : BwireAppServiceBase, IStreetAppService
    {
        private readonly IStreetDomainService _streetDomainService;
        public StreetAppService(IStreetDomainService streetDomainService)
        {
            _streetDomainService = streetDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _streetDomainService.Get().ToList();
            IEnumerable<StreetDto> data = ObjectMapper.Map<List<StreetDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<StreetDto>();
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
        public async Task<IList<StreetDto>> GetAllAsync()
        {
            var list = await _streetDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<StreetDto>>(list);
        }
        public async Task<StreetDto> GetByIdAsync(long id)
        {
            var street = await _streetDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<StreetDto>(street);
        }
        public async Task<CreateStreetDto> CreateAsync(CreateStreetDto streetDto)
        {
            var street = ObjectMapper.Map<Street>(streetDto);
            var createdStreet = await _streetDomainService.CreateAsync(street);
            return ObjectMapper.Map<CreateStreetDto>(createdStreet);
        }
        public async Task<UpdateStreetDto> UpdateAsync(UpdateStreetDto streetDto)
        {
            var street = ObjectMapper.Map<Street>(streetDto);
            var updatedStreet = await _streetDomainService.UpdateAsync(street);
            return ObjectMapper.Map<UpdateStreetDto>(updatedStreet);
        }
        public async Task DeleteAsync(long id)
        {
            await _streetDomainService.DeleteAsync(id);
        }
    }
}

