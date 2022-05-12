using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class CreateMaterialUnitDto : EntityDto<long>
    {
        public int ChildValue { get; set; }
    }
}

