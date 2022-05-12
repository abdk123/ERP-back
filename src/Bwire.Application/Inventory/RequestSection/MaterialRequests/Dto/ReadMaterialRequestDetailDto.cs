using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Dto
{
   public class ReadMaterialRequestDetailDto : EntityDto<long>
    {
        public int quentity { get; set; }
    }
}

