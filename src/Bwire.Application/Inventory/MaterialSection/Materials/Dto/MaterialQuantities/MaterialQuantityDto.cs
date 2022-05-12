using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class MaterialQuantityDto : EntityDto<long>
    {
        public long? PlaceId { get; set; }
        public long? UnitId { get; set; }
        public int Value { get; set; }
    }
}

