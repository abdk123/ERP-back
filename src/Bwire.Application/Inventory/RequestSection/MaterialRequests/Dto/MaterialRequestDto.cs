using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Dto
{
   public class MaterialRequestDto : EntityDto<long>
    {
        public string Code { get; set; }
        public DateTime? RequestDate { get; set; }
        public int Status { get; set; }
    }
}

