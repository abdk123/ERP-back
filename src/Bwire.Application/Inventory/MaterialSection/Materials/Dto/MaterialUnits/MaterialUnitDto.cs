using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class MaterialUnitDto : EntityDto<long>
    {
        public int ChildValue { get; set; }
    }
}

