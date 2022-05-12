using Bwire.Inventory.WarehouseSection.Warehouses;
using Bwire.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.WarehouseSection.Categories
{
    public class WarehouseCategory : BwireEntity
    {
        public WarehouseCategory()
        {
            Warehouses = new List<Warehouse>();
            ChildCategories = new List<WarehouseCategory>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Oreder { get; set; }

        #region Warehouse Parent
        public long? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual WarehouseCategory Parent { get; set; }
        #endregion

        public virtual IList<Warehouse> Warehouses { get; set; }
        public virtual IList<WarehouseCategory> ChildCategories { get; set; }
    }
}