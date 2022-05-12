using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.WarehouseSection.Categories.Dto
{
   public class ReadWarehouseCategoryDto : EntityDto<long>
    {
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int oreder { get; set; }
    }
}

