using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Dto
{
   public class MaterialRequestDetailDto : EntityDto<long>
    {
        public int Quentity { get; set; }
    }
}

