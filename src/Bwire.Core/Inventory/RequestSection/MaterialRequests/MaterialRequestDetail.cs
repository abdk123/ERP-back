using Bwire.Inventory.Indexes;
using Bwire.Inventory.MaterialSection.Materials;
using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.RequestSection.MaterialRequests
{
    public class MaterialRequestDetail : BwireEntity
    {
        public int Quentity { get; set; }
        public Unit Unit { get; set; }

        #region Material
        public long MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion
    }
}
