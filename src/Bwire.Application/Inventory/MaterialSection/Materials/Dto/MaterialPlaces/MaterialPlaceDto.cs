using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class MaterialPlaceDto : EntityDto<long>
    {
        public MaterialPlaceDto()
        {
            Quantities = new List<MaterialQuantityDto>();
        }

        public IList<MaterialQuantityDto> Quantities { get; set; }
    }
}

