using Bwire.Inventory.WarehouseSection.Places;
using Bwire.Inventory.WarehouseSection.Warehouses;
using Bwire.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class MaterialPlace : BwireEntity
    {
        public MaterialPlace()
        {
            Quantities = new List<MaterialQuantity>();
        }

        #region Warehouse
        public long WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        #endregion

        #region Material
        public long MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion

        #region Place
        public long PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        #endregion

        public virtual IList<MaterialQuantity> Quantities { get; set; }
    }
}
