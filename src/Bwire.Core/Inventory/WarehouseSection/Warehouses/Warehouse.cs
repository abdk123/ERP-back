using Bwire.Inventory.Indexes;
using Bwire.Inventory.WarehouseSection.Categories;
using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.WarehouseSection.Warehouses
{
    public class Warehouse : BwireEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        #region City
        public long CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        #endregion

        #region Area
        public long AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }
        #endregion

        #region Street
        public long StreetId { get; set; }
        [ForeignKey("StreetId")]
        public virtual Street Street { get; set; }
        #endregion

        #region Warehouse Type
        public long WarehouseTypeId { get; set; }
        [ForeignKey("WarehouseTypeId")]
        public virtual WarehouseType WarehouseType { get; set; }
        #endregion

        #region Warehouse Category
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual WarehouseCategory Category { get; set; }
        #endregion

    }
}