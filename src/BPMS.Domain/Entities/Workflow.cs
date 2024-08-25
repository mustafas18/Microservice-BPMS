using BPMS.Domain.Enums;
using BpmsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Entities
{
    public class Workflow:BaseEntity<int>
    {
 
        public WorkflowTemplate WorkflowTemplate { get; set; }
        public string CreatorId { get;protected set; }
        public DateTime CreateDateTime { get; protected set; }= DateTime.Now;
        public DateTime? CompleteDateTime { get; protected set; }
        public WorkflowStatusEnum Status  { get; protected set; }
        public Workflow UpdateStatus(WorkflowStatusEnum status)
        {
            if (status== WorkflowStatusEnum.Completed)
            {
                CompleteDateTime = DateTime.Now;
            }
            Status = status;
            return this;
        }
    }
}
