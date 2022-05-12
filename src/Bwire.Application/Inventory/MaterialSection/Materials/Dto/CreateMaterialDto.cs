using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class CreateMaterialDto : EntityDto<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ManufacturerCode { get; set; }
        public int Max { get; set; }
        public int MaxInRequest { get; set; }
        public int Min { get; set; }
        public bool IsPerishable { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int GuaranteePeriod { get; set; }
        public float Price { get; set; }
    }
}

