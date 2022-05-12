using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Attributes.Dto
{
   public class UpdateAttributeDto : EntityDto<long>
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}

