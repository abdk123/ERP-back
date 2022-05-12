using Bwire.Inventory.Indexes;
using Bwire.Inventory.MaterialSection.Categories;
using Bwire.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class Material : BwireEntity
    {
        public Material()
        {
            AttributeValues = new List<AttributeValue>();
            CorrespondingMaterials = new List<CorrespondingMaterial>();
            Units = new List<MaterialUnit>();
            MaterialPlaces = new List<MaterialPlace>();
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
        public int GuaranteePeriod { get; set; } // month
        public float Price { get; set; }

        #region Material Category
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual MaterialCategory Category { get; set; }
        #endregion

        #region Manufacturer
        public long ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }
        #endregion

        #region List
        public virtual IList<AttributeValue> AttributeValues { get; set; }
        public virtual IList<MaterialUnit> Units { get; set; }
        
        public virtual IList<MaterialPlace> MaterialPlaces { get; set; }
        public virtual IList<CorrespondingMaterial> CorrespondingMaterials { get; set; }
        #endregion

    }
}
