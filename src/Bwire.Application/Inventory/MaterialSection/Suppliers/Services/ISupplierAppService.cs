using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Bwire.Inventory.MaterialSection.Suppliers.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Bwire.Inventory.MaterialSection.Suppliers.Services
{
    public interface ISupplierAppService : IApplicationService
    {
        ReadGrudDto Get([FromBody] DataManagerRequest dm);
        Task<IList<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(long id);
        Task<CreateSupplierDto> CreateAsync(CreateSupplierDto supplier);
        Task<UpdateSupplierDto> UpdateAsync(UpdateSupplierDto supplier);
        Task DeleteAsync(long id);
    }
}

