using Bwire.Inventory.WarehouseSection.Warehouses;
using Bwire.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials.MaterialActions
{
    public class MaterialAction : BwireEntity
    {
        public MaterialActionType ActionType { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? Date { get; set; }

        #region Material
        public long MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion

        #region Warehouse
        public long WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        #endregion
    }
}
