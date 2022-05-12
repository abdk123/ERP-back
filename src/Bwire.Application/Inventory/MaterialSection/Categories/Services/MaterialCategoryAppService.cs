using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.MaterialSection.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.MaterialSection.Categories.Services
{
    public class MaterialCategoryAppService : BwireAppServiceBase, IMaterialCategoryAppService
    {
        private readonly IMaterialCategoryDomainService _materialCategoryDomainService;
        public MaterialCategoryAppService(IMaterialCategoryDomainService materialCategoryDomainService)
        {
            _materialCategoryDomainService = materialCategoryDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialCategoryDomainService.Get().ToList();
            IEnumerable<MaterialCategoryDto> data = ObjectMapper.Map<List<MaterialCategoryDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialCategoryDto>();
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
        public async Task<IList<MaterialCategoryDto>> GetAllAsync()
        {
            var list = await _materialCategoryDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialCategoryDto>>(list);
        }
        public async Task<MaterialCategoryDto> GetByIdAsync(long id)
        {
            var materialCategory = await _materialCategoryDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialCategoryDto>(materialCategory);
        }
        public async Task<CreateMaterialCategoryDto> CreateAsync(CreateMaterialCategoryDto materialCategoryDto)
        {
            var materialCategory = ObjectMapper.Map<MaterialCategory>(materialCategoryDto);
            var createdMaterialCategory = await _materialCategoryDomainService.CreateAsync(materialCategory);
            return ObjectMapper.Map<CreateMaterialCategoryDto>(createdMaterialCategory);
        }
        public async Task<UpdateMaterialCategoryDto> UpdateAsync(UpdateMaterialCategoryDto materialCategoryDto)
        {
            var materialCategory = ObjectMapper.Map<MaterialCategory>(materialCategoryDto);
            var updatedMaterialCategory = await _materialCategoryDomainService.UpdateAsync(materialCategory);
            return ObjectMapper.Map<UpdateMaterialCategoryDto>(updatedMaterialCategory);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialCategoryDomainService.DeleteAsync(id);
        }
    }
}

