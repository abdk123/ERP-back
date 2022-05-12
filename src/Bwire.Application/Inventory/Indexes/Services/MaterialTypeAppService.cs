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
    public class MaterialTypeAppService : BwireAppServiceBase, IMaterialTypeAppService
    {
        private readonly IMaterialTypeDomainService _materialTypeDomainService;
        public MaterialTypeAppService(IMaterialTypeDomainService materialTypeDomainService)
        {
            _materialTypeDomainService = materialTypeDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialTypeDomainService.Get().ToList();
            IEnumerable<MaterialTypeDto> data = ObjectMapper.Map<List<MaterialTypeDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialTypeDto>();
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
        public async Task<IList<MaterialTypeDto>> GetAllAsync()
        {
            var list = await _materialTypeDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialTypeDto>>(list);
        }
        public async Task<MaterialTypeDto> GetByIdAsync(long id)
        {
            var materialType = await _materialTypeDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialTypeDto>(materialType);
        }
        public async Task<CreateMaterialTypeDto> CreateAsync(CreateMaterialTypeDto materialTypeDto)
        {
            var materialType = ObjectMapper.Map<MaterialType>(materialTypeDto);
            var createdMaterialType = await _materialTypeDomainService.CreateAsync(materialType);
            return ObjectMapper.Map<CreateMaterialTypeDto>(createdMaterialType);
        }
        public async Task<UpdateMaterialTypeDto> UpdateAsync(UpdateMaterialTypeDto materialTypeDto)
        {
            var materialType = ObjectMapper.Map<MaterialType>(materialTypeDto);
            var updatedMaterialType = await _materialTypeDomainService.UpdateAsync(materialType);
            return ObjectMapper.Map<UpdateMaterialTypeDto>(updatedMaterialType);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialTypeDomainService.DeleteAsync(id);
        }
    }
}

