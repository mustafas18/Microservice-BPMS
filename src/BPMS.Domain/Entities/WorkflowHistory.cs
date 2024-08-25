using BPMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Entities
{
    public class WorkflowHistory
    {
        public WorkflowHistory()
        {
            
        }
        public WorkflowHistory(int workflowId,
            int nodeId,
            string? assigneeId,
            DateTime modificationTime,
            WorkflowStatusEnum status)
        {
            WorkflowId = workflowId;
            NodeId = nodeId;
            AssigneeId = assigneeId;
            ModificationTime = modificationTime;
            Status = status;
        }
        public int WorkflowId { get; protected set; }
        public int NodeId { get; protected set; }
        public string? AssigneeId { get; protected set; }
        public DateTime CreatedTime { get; protected set; } = DateTime.Now;
        public DateTime ModificationTime { get; protected set; }
        public WorkflowStatusEnum Status { get; protected set; }
        public void UpdateStatus(WorkflowStatusEnum status)
        {
            Status = status;
            ModificationTime= DateTime.Now;

        }
    }
}
