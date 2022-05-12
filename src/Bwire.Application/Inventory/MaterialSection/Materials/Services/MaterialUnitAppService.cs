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
    public class MaterialUnitAppService : BwireAppServiceBase, IMaterialUnitAppService
    {
        private readonly IMaterialUnitDomainService _materialUnitDomainService;
        public MaterialUnitAppService(IMaterialUnitDomainService materialUnitDomainService)
        {
            _materialUnitDomainService = materialUnitDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialUnitDomainService.Get().ToList();
            IEnumerable<MaterialUnitDto> data = ObjectMapper.Map<List<MaterialUnitDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialUnitDto>();
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
        public async Task<IList<MaterialUnitDto>> GetAllAsync()
        {
            var list = await _materialUnitDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialUnitDto>>(list);
        }
        public async Task<MaterialUnitDto> GetByIdAsync(long id)
        {
            var materialUnit = await _materialUnitDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialUnitDto>(materialUnit);
        }
        public async Task<CreateMaterialUnitDto> CreateAsync(CreateMaterialUnitDto materialUnitDto)
        {
            var materialUnit = ObjectMapper.Map<MaterialUnit>(materialUnitDto);
            var createdMaterialUnit = await _materialUnitDomainService.CreateAsync(materialUnit);
            return ObjectMapper.Map<CreateMaterialUnitDto>(createdMaterialUnit);
        }
        public async Task<UpdateMaterialUnitDto> UpdateAsync(UpdateMaterialUnitDto materialUnitDto)
        {
            var materialUnit = ObjectMapper.Map<MaterialUnit>(materialUnitDto);
            var updatedMaterialUnit = await _materialUnitDomainService.UpdateAsync(materialUnit);
            return ObjectMapper.Map<UpdateMaterialUnitDto>(updatedMaterialUnit);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialUnitDomainService.DeleteAsync(id);
        }
    }
}

