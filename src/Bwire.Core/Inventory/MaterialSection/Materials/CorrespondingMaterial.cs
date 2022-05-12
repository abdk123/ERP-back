using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class CorrespondingMaterial : BwireEntity
    {
        public long TargetMaterialId { get; set; }

        #region Material
        public long? MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion
    }
}
