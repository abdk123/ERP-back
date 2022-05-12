using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.RequestSection.MaterialRequests.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Services
{
    public class MaterialRequestAppService : BwireAppServiceBase, IMaterialRequestAppService
    {
        private readonly IMaterialRequestDomainService _materialRequestDomainService;
        public MaterialRequestAppService(IMaterialRequestDomainService materialRequestDomainService)
        {
            _materialRequestDomainService = materialRequestDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialRequestDomainService.Get().ToList();
            IEnumerable<MaterialRequestDto> data = ObjectMapper.Map<List<MaterialRequestDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialRequestDto>();
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
        public async Task<IList<MaterialRequestDto>> GetAllAsync()
        {
            var list = await _materialRequestDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialRequestDto>>(list);
        }
        public async Task<MaterialRequestDto> GetByIdAsync(long id)
        {
            var materialRequest = await _materialRequestDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialRequestDto>(materialRequest);
        }
        public async Task<CreateMaterialRequestDto> CreateAsync(CreateMaterialRequestDto materialRequestDto)
        {
            var materialRequest = ObjectMapper.Map<MaterialRequest>(materialRequestDto);
            var createdMaterialRequest = await _materialRequestDomainService.CreateAsync(materialRequest);
            return ObjectMapper.Map<CreateMaterialRequestDto>(createdMaterialRequest);
        }
        public async Task<UpdateMaterialRequestDto> UpdateAsync(UpdateMaterialRequestDto materialRequestDto)
        {
            var materialRequest = ObjectMapper.Map<MaterialRequest>(materialRequestDto);
            var updatedMaterialRequest = await _materialRequestDomainService.UpdateAsync(materialRequest);
            return ObjectMapper.Map<UpdateMaterialRequestDto>(updatedMaterialRequest);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialRequestDomainService.DeleteAsync(id);
        }
    }
}

