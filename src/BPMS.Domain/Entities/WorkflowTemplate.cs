using System.Data;
using BPMS.Domain.Entities;

namespace BpmsDomain.Entities
{
    public class WorkflowTemplate:BaseEntity<int>
    {
        public WorkflowTemplate()
        {
                
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Node>? Nodes { get; private set; } 
    }
}
