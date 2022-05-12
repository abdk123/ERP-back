using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.WarehouseSection.Places.Dto
{
   public class ReadPlaceDto : EntityDto<long>
    {
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }
}

