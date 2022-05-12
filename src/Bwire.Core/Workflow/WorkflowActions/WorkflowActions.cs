using Bwire.Authorization.Users;
using Bwire.Shared;
using Bwire.Workflow.WorkflowApprovals;
using Bwire.Workflow.WorkFlowSettings;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwire.Workflow.WorkflowActions
{
    public class WorkflowActions : BwireEntity
    {
        public long ActionId { get; set; }
        public WorkflowType WorkflowType { get; set; }
        public WorkflowApprovalStatus Status { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Description { get; set; }

        #region Current User
        public long? CurrentUserId { get; set; }

        [ForeignKey("CurrentUserId")]
        public User CurrentUser { get; set; }
        #endregion

        #region Next User
        public long? NextUserId { get; set; }

        [ForeignKey("NextUserId")]
        public User NextUser { get; set; }
        #endregion
    }
}
