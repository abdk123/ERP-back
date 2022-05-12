using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Bwire.Workflow.WorkflowApprovals;
using System.Collections.Generic;

namespace Bwire.Workflow.WorkFlowSettings
{
    public class WorkFlowSetting : FullAuditedEntity<long>, IMayHaveTenant
    {
        public WorkFlowSetting()
        {
            Approvals = new List<WorkflowApproval>();
        }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public bool IsFinished { get; set; }
        public int? Step => Approvals.Count > 0 ? Approvals.Count : 0;

        public IList<WorkflowApproval> Approvals { get; set; }
    }
}
