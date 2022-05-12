using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.WarehouseSection.Places.Dto
{
   public class UpdatePlaceDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

