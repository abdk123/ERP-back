using Bwire.Inventory.Indexes;
using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class MaterialUnit : BwireEntity
    {

        #region Unit
        public long UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        #endregion

        #region Material
        public long MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion

        #region Child
        public long? ChildId { get; set; }
        [ForeignKey("ChildId")]
        public virtual MaterialUnit Child { get; set; }
        #endregion

        public int ChildValue { get; set; }
    }
}
