using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.MaterialSection.Materials.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.MaterialSection.Materials.Services
{
    public class AttributeValueAppService : BwireAppServiceBase, IAttributeValueAppService
    {
        private readonly IAttributeValueDomainService _attributeValueDomainService;
        public AttributeValueAppService(IAttributeValueDomainService attributeValueDomainService)
        {
            _attributeValueDomainService = attributeValueDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _attributeValueDomainService.Get().ToList();
            IEnumerable<AttributeValueDto> data = ObjectMapper.Map<List<AttributeValueDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<AttributeValueDto>();
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
        public async Task<IList<AttributeValueDto>> GetAllAsync()
        {
            var list = await _attributeValueDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<AttributeValueDto>>(list);
        }
        public async Task<AttributeValueDto> GetByIdAsync(long id)
        {
            var attributeValue = await _attributeValueDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<AttributeValueDto>(attributeValue);
        }
        public async Task<CreateAttributeValueDto> CreateAsync(CreateAttributeValueDto attributeValueDto)
        {
            var attributeValue = ObjectMapper.Map<AttributeValue>(attributeValueDto);
            var createdAttributeValue = await _attributeValueDomainService.CreateAsync(attributeValue);
            return ObjectMapper.Map<CreateAttributeValueDto>(createdAttributeValue);
        }
        public async Task<UpdateAttributeValueDto> UpdateAsync(UpdateAttributeValueDto attributeValueDto)
        {
            var attributeValue = ObjectMapper.Map<AttributeValue>(attributeValueDto);
            var updatedAttributeValue = await _attributeValueDomainService.UpdateAsync(attributeValue);
            return ObjectMapper.Map<UpdateAttributeValueDto>(updatedAttributeValue);
        }
        public async Task DeleteAsync(long id)
        {
            await _attributeValueDomainService.DeleteAsync(id);
        }
    }
}

