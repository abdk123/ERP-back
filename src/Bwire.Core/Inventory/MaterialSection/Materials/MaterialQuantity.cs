using Bwire.Shared;

namespace Bwire.Inventory.MaterialSection.Materials
{
    public class MaterialQuantity : BwireEntity
    {
        #region Material Unit
        public long? UnitId { get; set; }
        public MaterialUnit Unit { get; set; }
        #endregion

        #region Material Place
        public long? PlaceId { get; set; }
        public MaterialPlace Place { get; set; }
        #endregion

        public int Value { get; set; }
    }
}
