using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class ReadMaterialUnitDto : EntityDto<long>
    {
        public int childValue { get; set; }
    }
}

