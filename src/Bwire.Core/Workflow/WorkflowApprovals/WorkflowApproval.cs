using Bwire.Authorization.Users;
using Bwire.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Workflow.WorkflowApprovals
{
    public class WorkflowApproval : BwireEntity
    {
        public int Order { get; set; }
        public WorkflowApprovalStatus Status { get; set; }

        #region User
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }
}
