using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.WarehouseSection.Warehouses.Dto
{
   public class ReadWarehouseDto : EntityDto<long>
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}

