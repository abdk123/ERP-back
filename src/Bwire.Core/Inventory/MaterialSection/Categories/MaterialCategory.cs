using Bwire.Inventory.MaterialSection.Materials;
using Bwire.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.MaterialSection.Categories
{
    public class MaterialCategory : BwireEntity
    {
        public MaterialCategory()
        {
            Materials = new List<Material>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Oreder { get; set; }

        #region Material Parent
        public long? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual MaterialCategory Parent { get; set; }
        #endregion

        public virtual IList<Material> Materials { get; set; }
    }
}
