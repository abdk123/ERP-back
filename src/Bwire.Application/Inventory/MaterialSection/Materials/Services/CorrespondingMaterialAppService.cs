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
    public class CorrespondingMaterialAppService : BwireAppServiceBase, ICorrespondingMaterialAppService
    {
        private readonly ICorrespondingMaterialDomainService _correspondingMaterialDomainService;
        public CorrespondingMaterialAppService(ICorrespondingMaterialDomainService correspondingMaterialDomainService)
        {
            _correspondingMaterialDomainService = correspondingMaterialDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _correspondingMaterialDomainService.Get().ToList();
            IEnumerable<CorrespondingMaterialDto> data = ObjectMapper.Map<List<CorrespondingMaterialDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<CorrespondingMaterialDto>();
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
        public async Task<IList<CorrespondingMaterialDto>> GetAllAsync()
        {
            var list = await _correspondingMaterialDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<CorrespondingMaterialDto>>(list);
        }
        public async Task<CorrespondingMaterialDto> GetByIdAsync(long id)
        {
            var correspondingMaterial = await _correspondingMaterialDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<CorrespondingMaterialDto>(correspondingMaterial);
        }
        public async Task<CreateCorrespondingMaterialDto> CreateAsync(CreateCorrespondingMaterialDto correspondingMaterialDto)
        {
            var correspondingMaterial = ObjectMapper.Map<CorrespondingMaterial>(correspondingMaterialDto);
            var createdCorrespondingMaterial = await _correspondingMaterialDomainService.CreateAsync(correspondingMaterial);
            return ObjectMapper.Map<CreateCorrespondingMaterialDto>(createdCorrespondingMaterial);
        }
        public async Task<UpdateCorrespondingMaterialDto> UpdateAsync(UpdateCorrespondingMaterialDto correspondingMaterialDto)
        {
            var correspondingMaterial = ObjectMapper.Map<CorrespondingMaterial>(correspondingMaterialDto);
            var updatedCorrespondingMaterial = await _correspondingMaterialDomainService.UpdateAsync(correspondingMaterial);
            return ObjectMapper.Map<UpdateCorrespondingMaterialDto>(updatedCorrespondingMaterial);
        }
        public async Task DeleteAsync(long id)
        {
            await _correspondingMaterialDomainService.DeleteAsync(id);
        }
    }
}

