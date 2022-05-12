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
    public class MaterialRequestDetailAppService : BwireAppServiceBase, IMaterialRequestDetailAppService
    {
        private readonly IMaterialRequestDetailDomainService _materialRequestDetailDomainService;
        public MaterialRequestDetailAppService(IMaterialRequestDetailDomainService materialRequestDetailDomainService)
        {
            _materialRequestDetailDomainService = materialRequestDetailDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialRequestDetailDomainService.Get().ToList();
            IEnumerable<MaterialRequestDetailDto> data = ObjectMapper.Map<List<MaterialRequestDetailDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialRequestDetailDto>();
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
        public async Task<IList<MaterialRequestDetailDto>> GetAllAsync()
        {
            var list = await _materialRequestDetailDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialRequestDetailDto>>(list);
        }
        public async Task<MaterialRequestDetailDto> GetByIdAsync(long id)
        {
            var materialRequestDetail = await _materialRequestDetailDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialRequestDetailDto>(materialRequestDetail);
        }
        public async Task<CreateMaterialRequestDetailDto> CreateAsync(CreateMaterialRequestDetailDto materialRequestDetailDto)
        {
            var materialRequestDetail = ObjectMapper.Map<MaterialRequestDetail>(materialRequestDetailDto);
            var createdMaterialRequestDetail = await _materialRequestDetailDomainService.CreateAsync(materialRequestDetail);
            return ObjectMapper.Map<CreateMaterialRequestDetailDto>(createdMaterialRequestDetail);
        }
        public async Task<UpdateMaterialRequestDetailDto> UpdateAsync(UpdateMaterialRequestDetailDto materialRequestDetailDto)
        {
            var materialRequestDetail = ObjectMapper.Map<MaterialRequestDetail>(materialRequestDetailDto);
            var updatedMaterialRequestDetail = await _materialRequestDetailDomainService.UpdateAsync(materialRequestDetail);
            return ObjectMapper.Map<UpdateMaterialRequestDetailDto>(updatedMaterialRequestDetail);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialRequestDetailDomainService.DeleteAsync(id);
        }
    }
}

