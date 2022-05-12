using Bwire.Inventory.MaterialSection.Attributes;
using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class AttributeValue : BwireEntity
    {
        public AttributeType AttributeType { get; set; }
        public string Value { get; set; }

        #region Attribute Option // تؤخذ القيمة من هذا الحقل في حال كان نوعها option
        public long AttributeOptionId { get; set; }
        [ForeignKey("AttributeOptionId")]
        public virtual AttributeOption AttributeOption { get; set; }
        #endregion

        #region Attribute
        public long? AttributeId { get; set; }
        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }
        #endregion

        #region Material
        public long MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion

    }
}
