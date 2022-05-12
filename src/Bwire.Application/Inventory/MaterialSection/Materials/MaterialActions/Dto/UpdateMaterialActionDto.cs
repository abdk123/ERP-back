using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions.Dto
{
   public class UpdateMaterialActionDto : EntityDto<long>
    {
        public int ActionType { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? Date { get; set; }
    }
}

