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
    public class AttributeOptionAppService : BwireAppServiceBase, IAttributeOptionAppService
    {
        private readonly IAttributeOptionDomainService _attributeOptionDomainService;
        public AttributeOptionAppService(IAttributeOptionDomainService attributeOptionDomainService)
        {
            _attributeOptionDomainService = attributeOptionDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _attributeOptionDomainService.Get().ToList();
            IEnumerable<AttributeOptionDto> data = ObjectMapper.Map<List<AttributeOptionDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<AttributeOptionDto>();
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
        public async Task<IList<AttributeOptionDto>> GetAllAsync()
        {
            var list = await _attributeOptionDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<AttributeOptionDto>>(list);
        }
        public async Task<AttributeOptionDto> GetByIdAsync(long id)
        {
            var attributeOption = await _attributeOptionDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<AttributeOptionDto>(attributeOption);
        }
        public async Task<CreateAttributeOptionDto> CreateAsync(CreateAttributeOptionDto attributeOptionDto)
        {
            var attributeOption = ObjectMapper.Map<AttributeOption>(attributeOptionDto);
            var createdAttributeOption = await _attributeOptionDomainService.CreateAsync(attributeOption);
            return ObjectMapper.Map<CreateAttributeOptionDto>(createdAttributeOption);
        }
        public async Task<UpdateAttributeOptionDto> UpdateAsync(UpdateAttributeOptionDto attributeOptionDto)
        {
            var attributeOption = ObjectMapper.Map<AttributeOption>(attributeOptionDto);
            var updatedAttributeOption = await _attributeOptionDomainService.UpdateAsync(attributeOption);
            return ObjectMapper.Map<UpdateAttributeOptionDto>(updatedAttributeOption);
        }
        public async Task DeleteAsync(long id)
        {
            await _attributeOptionDomainService.DeleteAsync(id);
        }
    }
}

