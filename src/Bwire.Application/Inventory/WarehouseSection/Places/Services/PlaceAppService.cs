using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.WarehouseSection.Places.Dto;
using Syncfusion.EJ2.Base;
using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace Bwire.Inventory.WarehouseSection.Places.Services
{
    public class PlaceAppService : BwireAppServiceBase, IPlaceAppService
    {
        private readonly IPlaceDomainService _placeDomainService;
        public PlaceAppService(IPlaceDomainService placeDomainService)
        {
            _placeDomainService = placeDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _placeDomainService.Get().ToList();
            IEnumerable<PlaceDto> data = ObjectMapper.Map<List<PlaceDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<PlaceDto>();
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
        public async Task<IList<PlaceDto>> GetAllAsync()
        {
            var list = await _placeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<PlaceDto>>(list);
        }
        public async Task<PlaceDto> GetByIdAsync(long id)
        {
            var place = await _placeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<PlaceDto>(place);
        }
        public async Task<CreatePlaceDto> CreateAsync(CreatePlaceDto placeDto)
        {
            var place = ObjectMapper.Map<Place>(placeDto);
            var createdPlace = await _placeDomainService.CreateAsync(place);
            return ObjectMapper.Map<CreatePlaceDto>(createdPlace);
        }
        public async Task<UpdatePlaceDto> UpdateAsync(UpdatePlaceDto placeDto)
        {
            var place = ObjectMapper.Map<Place>(placeDto);
            var updatedPlace = await _placeDomainService.UpdateAsync(place);
            return ObjectMapper.Map<UpdatePlaceDto>(updatedPlace);
        }
        public async Task DeleteAsync(long id)
        {
            await _placeDomainService.DeleteAsync(id);
        }
    }
}

