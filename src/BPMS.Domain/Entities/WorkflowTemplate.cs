using System.Data;

namespace BpmsDomain.Entities
{
    public class WorkflowTemplate:BaseEntity<int>
    {
        public WorkflowTemplate()
        {
                
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Node> Nodes { get; private set; } 
    }
}
