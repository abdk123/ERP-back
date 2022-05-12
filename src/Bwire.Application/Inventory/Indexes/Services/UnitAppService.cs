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
    public class UnitAppService : BwireAppServiceBase, IUnitAppService
    {
        private readonly IUnitDomainService _unitDomainService;
        public UnitAppService(IUnitDomainService unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _unitDomainService.Get().ToList();
            IEnumerable<UnitDto> data = ObjectMapper.Map<List<UnitDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<UnitDto>();
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
        public async Task<IList<UnitDto>> GetAllAsync()
        {
            var list = await _unitDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<UnitDto>>(list);
        }
        public async Task<UnitDto> GetByIdAsync(long id)
        {
            var unit = await _unitDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<UnitDto>(unit);
        }
        public async Task<CreateUnitDto> CreateAsync(CreateUnitDto unitDto)
        {
            var unit = ObjectMapper.Map<Unit>(unitDto);
            var createdUnit = await _unitDomainService.CreateAsync(unit);
            return ObjectMapper.Map<CreateUnitDto>(createdUnit);
        }
        public async Task<UpdateUnitDto> UpdateAsync(UpdateUnitDto unitDto)
        {
            var unit = ObjectMapper.Map<Unit>(unitDto);
            var updatedUnit = await _unitDomainService.UpdateAsync(unit);
            return ObjectMapper.Map<UpdateUnitDto>(updatedUnit);
        }
        public async Task DeleteAsync(long id)
        {
            await _unitDomainService.DeleteAsync(id);
        }
    }
}

