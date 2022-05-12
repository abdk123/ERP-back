using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Suppliers.Dto
{
    public class CreateSupplierDto : EntityDto<long>
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
}

