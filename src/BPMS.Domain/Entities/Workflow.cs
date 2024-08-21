using System.Data;

namespace BpmsDomain.Entities
{
    public class Workflow:BaseEntity
    {
        public Workflow()
        {
                
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Node> Nodes { get; private set; } 
    }
}
