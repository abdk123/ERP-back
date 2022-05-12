using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Attributes.Dto
{
   public class ReadAttributeOptionDto : EntityDto<long>
    {
        public string name { get; set; }
        public int order { get; set; }
    }
}

