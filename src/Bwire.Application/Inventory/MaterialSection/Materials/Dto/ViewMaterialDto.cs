using Abp.Application.Services.Dto;
using Bwire.Inventory.Indexes.Dto;
using Bwire.Inventory.MaterialSection.Categories.Dto;
using System;
using System.Collections.Generic;

namespace Bwire.Inventory.MaterialSection.Materials.Dto
{
    public class ViewMaterialDto : EntityDto<long>
    {
        public ViewMaterialDto()
        {
            AttributeValues = new List<AttributeValueDto>();
            CorrespondingMaterials = new List<CorrespondingMaterialDto>();
            Units = new List<MaterialUnitDto>();
            MaterialPlaces = new List<MaterialPlaceDto>();
        }

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
        public long CategoryId { get; set; }
        public long ManufacturerId { get; set; }
        public MaterialCategoryDto Category { get; set; }
        public ManufacturerDto Manufacturer { get; set; }

        public virtual IList<AttributeValueDto> AttributeValues { get; set; }
        public virtual IList<MaterialUnitDto> Units { get; set; }
        public virtual IList<MaterialPlaceDto> MaterialPlaces { get; set; }
        public virtual IList<CorrespondingMaterialDto> CorrespondingMaterials { get; set; }
    }
}
