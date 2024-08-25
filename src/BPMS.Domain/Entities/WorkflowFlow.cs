using BPMS.Domain.Enums;
using BpmsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Entities
{
    public class WorkflowFlow : BaseEntity<int>
    {
        public WorkflowFlow() { }
        public WorkflowFlow(int workflowId, int nodeId, DateTime modificationTime, WorkflowStatusEnum status)
        {
            WorkflowId = workflowId;
            NodeId = nodeId;
            ModificationTime = modificationTime;
            Status = status;
        }
        public WorkflowFlow UpdateFlow(DateTime modificationTime, WorkflowStatusEnum status)
        {
            ModificationTime=modificationTime;
            Status=status;
            return this;
        }
        public int WorkflowId { get; protected set; }
        public int NodeId { get; protected set; }
        public DateTime ModificationTime { get; protected set; }
        public WorkflowStatusEnum Status { get; protected set; }
    }
}
