using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class ReadAttributeValueDto : EntityDto<long>
    {
        public int attributeType { get; set; }
        public string value { get; set; }
    }
}

