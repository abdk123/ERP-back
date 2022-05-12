using System;
using Abp.Application.Services.Dto;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
   public class ReadMaterialDto : EntityDto<long>
    {
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string manufacturerCode { get; set; }
        public int max { get; set; }
        public int maxInRequest { get; set; }
        public int min { get; set; }
        public bool isPerishable { get; set; }
        public DateTime? expirationDate { get; set; }
        public int guaranteePeriod { get; set; }
        public float price { get; set; }
    }
}

