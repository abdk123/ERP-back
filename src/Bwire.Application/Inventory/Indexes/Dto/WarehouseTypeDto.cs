using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.Indexes.Dto
{
    public class WarehouseTypeDto : EntityDto<long>
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}

