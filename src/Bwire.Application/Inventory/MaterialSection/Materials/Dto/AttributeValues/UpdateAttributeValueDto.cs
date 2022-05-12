using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class UpdateAttributeValueDto : EntityDto<long>
    {
        public int AttributeType { get; set; }
        public string Value { get; set; }
    }
}

