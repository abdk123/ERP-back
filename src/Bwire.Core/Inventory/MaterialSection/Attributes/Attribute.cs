using Bwire.Shared;
using System.Collections.Generic;

namespace Bwire.Inventory.MaterialSection.Attributes
{
    public class Attribute : BwireEntity
    {
        public Attribute()
        {
            Options = new List<AttributeOption>();
        }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual IList<AttributeOption> Options { get; set; }
    }
}
