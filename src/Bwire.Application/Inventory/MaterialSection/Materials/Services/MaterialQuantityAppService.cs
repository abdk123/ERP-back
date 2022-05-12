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
    public class MaterialQuantityAppService : BwireAppServiceBase, IMaterialQuantityAppService
    {
        private readonly IMaterialQuantityDomainService _materialQuantityDomainService;
        public MaterialQuantityAppService(IMaterialQuantityDomainService materialQuantityDomainService)
        {
            _materialQuantityDomainService = materialQuantityDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialQuantityDomainService.Get().ToList();
            IEnumerable<MaterialQuantityDto> data = ObjectMapper.Map<List<MaterialQuantityDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialQuantityDto>();
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
        public async Task<IList<MaterialQuantityDto>> GetAllAsync()
        {
            var list = await _materialQuantityDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialQuantityDto>>(list);
        }
        public async Task<MaterialQuantityDto> GetByIdAsync(long id)
        {
            var materialQuantity = await _materialQuantityDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialQuantityDto>(materialQuantity);
        }
        public async Task<CreateMaterialQuantityDto> CreateAsync(CreateMaterialQuantityDto materialQuantityDto)
        {
            var materialQuantity = ObjectMapper.Map<MaterialQuantity>(materialQuantityDto);
            var createdMaterialQuantity = await _materialQuantityDomainService.CreateAsync(materialQuantity);
            return ObjectMapper.Map<CreateMaterialQuantityDto>(createdMaterialQuantity);
        }
        public async Task<UpdateMaterialQuantityDto> UpdateAsync(UpdateMaterialQuantityDto materialQuantityDto)
        {
            var materialQuantity = ObjectMapper.Map<MaterialQuantity>(materialQuantityDto);
            var updatedMaterialQuantity = await _materialQuantityDomainService.UpdateAsync(materialQuantity);
            return ObjectMapper.Map<UpdateMaterialQuantityDto>(updatedMaterialQuantity);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialQuantityDomainService.DeleteAsync(id);
        }
    }
}

