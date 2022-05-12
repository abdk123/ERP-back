using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Suppliers.Dto
{
   public class ReadSupplierDto : EntityDto<long>
    {
        public string name { get; set; }
        public int type { get; set; }
    }
}

