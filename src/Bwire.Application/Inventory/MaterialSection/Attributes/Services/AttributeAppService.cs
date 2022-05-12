using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.MaterialSection.Attributes.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.MaterialSection.Attributes.Services
{
    public class AttributeAppService : BwireAppServiceBase, IAttributeAppService
    {
        private readonly IAttributeDomainService _attributeDomainService;
        public AttributeAppService(IAttributeDomainService attributeDomainService)
        {
            _attributeDomainService = attributeDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _attributeDomainService.Get().ToList();
            IEnumerable<AttributeDto> data = ObjectMapper.Map<List<AttributeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<AttributeDto>();
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
        public async Task<IList<AttributeDto>> GetAllAsync()
        {
            var list = await _attributeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<AttributeDto>>(list);
        }
        public async Task<AttributeDto> GetByIdAsync(long id)
        {
            var attribute = await _attributeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<AttributeDto>(attribute);
        }
        public async Task<CreateAttributeDto> CreateAsync(CreateAttributeDto attributeDto)
        {
            var attribute = ObjectMapper.Map<Attribute>(attributeDto);
            var createdAttribute = await _attributeDomainService.CreateAsync(attribute);
            return ObjectMapper.Map<CreateAttributeDto>(createdAttribute);
        }
        public async Task<UpdateAttributeDto> UpdateAsync(UpdateAttributeDto attributeDto)
        {
            var attribute = ObjectMapper.Map<Attribute>(attributeDto);
            var updatedAttribute = await _attributeDomainService.UpdateAsync(attribute);
            return ObjectMapper.Map<UpdateAttributeDto>(updatedAttribute);
        }
        public async Task DeleteAsync(long id)
        {
            await _attributeDomainService.DeleteAsync(id);
        }
    }
}

