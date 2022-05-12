using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Bwire.Shared
{
    public class BwireEntity : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
    }
}
