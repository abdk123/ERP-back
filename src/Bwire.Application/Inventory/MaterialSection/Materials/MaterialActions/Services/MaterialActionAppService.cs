using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.MaterialSection.Materials.MaterialActions.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Services
{
    public class MaterialActionAppService : BwireAppServiceBase, IMaterialActionAppService
    {
        private readonly IMaterialActionDomainService _materialActionDomainService;
        public MaterialActionAppService(IMaterialActionDomainService materialActionDomainService)
        {
            _materialActionDomainService = materialActionDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialActionDomainService.Get().ToList();
            IEnumerable<MaterialActionDto> data = ObjectMapper.Map<List<MaterialActionDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialActionDto>();
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
        public async Task<IList<MaterialActionDto>> GetAllAsync()
        {
            var list = await _materialActionDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialActionDto>>(list);
        }
        public async Task<MaterialActionDto> GetByIdAsync(long id)
        {
            var materialAction = await _materialActionDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialActionDto>(materialAction);
        }
        public async Task<CreateMaterialActionDto> CreateAsync(CreateMaterialActionDto materialActionDto)
        {
            var materialAction = ObjectMapper.Map<MaterialAction>(materialActionDto);
            var createdMaterialAction = await _materialActionDomainService.CreateAsync(materialAction);
            return ObjectMapper.Map<CreateMaterialActionDto>(createdMaterialAction);
        }
        public async Task<UpdateMaterialActionDto> UpdateAsync(UpdateMaterialActionDto materialActionDto)
        {
            var materialAction = ObjectMapper.Map<MaterialAction>(materialActionDto);
            var updatedMaterialAction = await _materialActionDomainService.UpdateAsync(materialAction);
            return ObjectMapper.Map<UpdateMaterialActionDto>(updatedMaterialAction);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialActionDomainService.DeleteAsync(id);
        }
    }
}

