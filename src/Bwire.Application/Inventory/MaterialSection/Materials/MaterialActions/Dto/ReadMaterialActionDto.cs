using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Dto
{
   public class ReadMaterialActionDto : EntityDto<long>
    {
        public int actionType { get; set; }
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public DateTime? date { get; set; }
    }
}

