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
    public class ManufacturerAppService : BwireAppServiceBase, IManufacturerAppService
    {
        private readonly IManufacturerDomainService _manufacturerDomainService;
        public ManufacturerAppService(IManufacturerDomainService manufacturerDomainService)
        {
            _manufacturerDomainService = manufacturerDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _manufacturerDomainService.Get().ToList();
            IEnumerable<ManufacturerDto> data = ObjectMapper.Map<List<ManufacturerDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<ManufacturerDto>();
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
        public async Task<IList<ManufacturerDto>> GetAllAsync()
        {
            var list = await _manufacturerDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<ManufacturerDto>>(list);
        }
        public async Task<ManufacturerDto> GetByIdAsync(long id)
        {
            var manufacturer = await _manufacturerDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<ManufacturerDto>(manufacturer);
        }
        public async Task<CreateManufacturerDto> CreateAsync(CreateManufacturerDto manufacturerDto)
        {
            var manufacturer = ObjectMapper.Map<Manufacturer>(manufacturerDto);
            var createdManufacturer = await _manufacturerDomainService.CreateAsync(manufacturer);
            return ObjectMapper.Map<CreateManufacturerDto>(createdManufacturer);
        }
        public async Task<UpdateManufacturerDto> UpdateAsync(UpdateManufacturerDto manufacturerDto)
        {
            var manufacturer = ObjectMapper.Map<Manufacturer>(manufacturerDto);
            var updatedManufacturer = await _manufacturerDomainService.UpdateAsync(manufacturer);
            return ObjectMapper.Map<UpdateManufacturerDto>(updatedManufacturer);
        }
        public async Task DeleteAsync(long id)
        {
            await _manufacturerDomainService.DeleteAsync(id);
        }
    }
}

