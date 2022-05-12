using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.RequestSection.MaterialRequests.Dto
{
   public class ReadMaterialRequestDto : EntityDto<long>
    {
        public string code { get; set; }
        public DateTime? requestDate { get; set; }
        public int status { get; set; }
    }
}

