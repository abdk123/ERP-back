using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Dto
{
   public class CreateMaterialRequestDetailDto : EntityDto<long>
    {
        public int Quentity { get; set; }
    }
}

