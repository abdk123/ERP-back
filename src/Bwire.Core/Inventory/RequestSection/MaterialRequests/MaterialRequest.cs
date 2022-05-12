using Bwire.Shared;
using System;
using System.Collections.Generic;

namespace Bwire.Inventory.RequestSection.MaterialRequests
{
    public class MaterialRequest : BwireEntity
    {
        public MaterialRequest()
        {
            RequestDetails = new List<MaterialRequestDetail>();
        }
        public string Code { get; set; }
        public DateTime? RequestDate { get; set; }
        public MaterialRequestStatus Status { get; set; }

        public IList<MaterialRequestDetail> RequestDetails { get; set; }
    }
}
