using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Dto
{
   public class WarehouseDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

