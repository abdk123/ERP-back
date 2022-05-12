using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Attributes
{
    public class AttributeOption : BwireEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }

        #region Material Attribute
        public long AttributeId { get; set; }
        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }
        #endregion
    }
}

