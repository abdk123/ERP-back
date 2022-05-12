using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Categories.Dto
{
   public class CreateMaterialCategoryDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Oreder { get; set; }
    }
}

