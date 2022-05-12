using Bwire.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Inventory.WarehouseSection.Places
{
    public class Place : BwireEntity
    {
        public Place()
        {
            ChildSections = new List<Place>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        #region Section Parent
        public long? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Place Parent { get; set; }
        #endregion

        public virtual IList<Place> ChildSections { get; set; }
    }
}
