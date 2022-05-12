using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bwire.Inventory.MaterialSection.Suppliers.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace Bwire.Inventory.MaterialSection.Suppliers.Services
{
    public class SupplierAppService : BwireAppServiceBase, ISupplierAppService
    {
        private readonly ISupplierDomainService _supplierDomainService;
        public SupplierAppService(ISupplierDomainService supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }
        public ReadGrudDto Get([FromBody] DataManagerRequest dm)
        {
            var list = _supplierDomainService.Get().ToList();
            IEnumerable<SupplierDto> data = ObjectMapper.Map<List<SupplierDto>>(list);
            var operations = new DataOperations();
            if (dm.Where != null)
            {
                data = operations.PerformFiltering(data, dm.Where, "and");
            }
            
            IEnumerable groupDs = new List<SupplierDto>();
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
        public async Task<IList<SupplierDto>> GetAllAsync()
        {
            var list = await _supplierDomainService.GetAllAsync();
            return ObjectMapper.Map<IList<SupplierDto>>(list);
        }
        public async Task<SupplierDto> GetByIdAsync(long id)
        {
            var supplier = await _supplierDomainService.GetByIdAsync(id);
            return ObjectMapper.Map<SupplierDto>(supplier);
        }
        public async Task<CreateSupplierDto> CreateAsync(CreateSupplierDto supplierDto)
        {
            var supplier = ObjectMapper.Map<Supplier>(supplierDto);
            var createdSupplier = await _supplierDomainService.CreateAsync(supplier);
            return ObjectMapper.Map<CreateSupplierDto>(createdSupplier);
        }
        public async Task<UpdateSupplierDto> UpdateAsync(UpdateSupplierDto supplierDto)
        {
            var supplier = ObjectMapper.Map<Supplier>(supplierDto);
            var updatedSupplier = await _supplierDomainService.UpdateAsync(supplier);
            return ObjectMapper.Map<UpdateSupplierDto>(updatedSupplier);
        }
        public async Task DeleteAsync(long id)
        {
            await _supplierDomainService.DeleteAsync(id);
        }
    }
}

