using Bwire.Shared;

namespace Bwire.Inventory.MaterialSection.Suppliers
{
    public class Supplier : BwireEntity
    {
        public string Name { get; set; }    
        public SupplierType Type { get; set; }

        //إضافة الافرع لكل مورد
    }
}
