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
    public class MaterialAppService : BwireAppServiceBase, IMaterialAppService
    {
        private readonly IMaterialDomainService _materialDomainService;
        public MaterialAppService(IMaterialDomainService materialDomainService)
        {
            _materialDomainService = materialDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialDomainService.Get().ToList();
            IEnumerable<MaterialDto> data = ObjectMapper.Map<List<MaterialDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialDto>();
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
        public async Task<IList<MaterialDto>> GetAllAsync()
        {
            var list = await _materialDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialDto>>(list);
        }
        public async Task<MaterialDto> GetByIdAsync(long id)
        {
            var material = await _materialDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialDto>(material);
        }
        public async Task<CreateMaterialDto> CreateAsync(CreateMaterialDto materialDto)
        {
            var material = ObjectMapper.Map<Material>(materialDto);
            var createdMaterial = await _materialDomainService.CreateAsync(material);
            return ObjectMapper.Map<CreateMaterialDto>(createdMaterial);
        }
        public async Task<UpdateMaterialDto> UpdateAsync(UpdateMaterialDto materialDto)
        {
            var material = ObjectMapper.Map<Material>(materialDto);
            var updatedMaterial = await _materialDomainService.UpdateAsync(material);
            return ObjectMapper.Map<UpdateMaterialDto>(updatedMaterial);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialDomainService.DeleteAsync(id);
        }
    }
}

