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
    public class CityAppService : BwireAppServiceBase, ICityAppService
    {
        private readonly ICityDomainService _cityDomainService;
        public CityAppService(ICityDomainService cityDomainService)
        {
            _cityDomainService = cityDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _cityDomainService.Get().ToList();
            IEnumerable<CityDto> data = ObjectMapper.Map<List<CityDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<CityDto>();
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
        public async Task<IList<CityDto>> GetAllAsync()
        {
            var list = await _cityDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<CityDto>>(list);
        }
        public async Task<CityDto> GetByIdAsync(long id)
        {
            var city = await _cityDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CityDto>(city);
        }
        public async Task<CreateCityDto> CreateAsync(CreateCityDto cityDto)
        {
            var city = ObjectMapper.Map<City>(cityDto);
            var createdCity = await _cityDomainService.CreateAsync(city);
            return ObjectMapper.Map<CreateCityDto>(createdCity);
        }
        public async Task<UpdateCityDto> UpdateAsync(UpdateCityDto cityDto)
        {
            var city = ObjectMapper.Map<City>(cityDto);
            var updatedCity = await _cityDomainService.UpdateAsync(city);
            return ObjectMapper.Map<UpdateCityDto>(updatedCity);
        }
        public async Task DeleteAsync(long id)
        {
            await _cityDomainService.DeleteAsync(id);
        }
    }
}

