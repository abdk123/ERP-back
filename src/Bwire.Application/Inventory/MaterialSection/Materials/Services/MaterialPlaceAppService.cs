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
    public class MaterialPlaceAppService : BwireAppServiceBase, IMaterialPlaceAppService
    {
        private readonly IMaterialPlaceDomainService _materialPlaceDomainService;
        public MaterialPlaceAppService(IMaterialPlaceDomainService materialPlaceDomainService)
        {
            _materialPlaceDomainService = materialPlaceDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _materialPlaceDomainService.Get().ToList();
            IEnumerable<MaterialPlaceDto> data = ObjectMapper.Map<List<MaterialPlaceDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<MaterialPlaceDto>();
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
        public async Task<IList<MaterialPlaceDto>> GetAllAsync()
        {
            var list = await _materialPlaceDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<MaterialPlaceDto>>(list);
        }
        public async Task<MaterialPlaceDto> GetByIdAsync(long id)
        {
            var materialPlace = await _materialPlaceDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<MaterialPlaceDto>(materialPlace);
        }
        public async Task<CreateMaterialPlaceDto> CreateAsync(CreateMaterialPlaceDto materialPlaceDto)
        {
            var materialPlace = ObjectMapper.Map<MaterialPlace>(materialPlaceDto);
            var createdMaterialPlace = await _materialPlaceDomainService.CreateAsync(materialPlace);
            return ObjectMapper.Map<CreateMaterialPlaceDto>(createdMaterialPlace);
        }
        public async Task<UpdateMaterialPlaceDto> UpdateAsync(UpdateMaterialPlaceDto materialPlaceDto)
        {
            var materialPlace = ObjectMapper.Map<MaterialPlace>(materialPlaceDto);
            var updatedMaterialPlace = await _materialPlaceDomainService.UpdateAsync(materialPlace);
            return ObjectMapper.Map<UpdateMaterialPlaceDto>(updatedMaterialPlace);
        }
        public async Task DeleteAsync(long id)
        {
            await _materialPlaceDomainService.DeleteAsync(id);
        }
    }
}

