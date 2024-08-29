using System.Data;
using BPMS.Domain.Dtos;
using BPMS.Domain.Entities;

namespace BpmsDomain.Entities
{
    public class WorkflowTemplate:BaseEntity<int>
    {
        public WorkflowTemplate()
        {
                
        }
        public WorkflowTemplate(string name,string description)
        {
            Name=name;
            Description=description;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Node>? Nodes { get; private set; }=new List<Node>();    
        public WorkflowTemplate UpdateInfo(string name, string description)
        {
            Name = name;
            Description = description;
            return this;
        }
        public WorkflowTemplate AddNode(Node node)
        {
            Nodes.Add(node);
            return this;
        }
        public WorkflowTemplate UpdateNode(Node input)
        {
            var node = Nodes.FirstOrDefault(s => s.Id == input.Id);
            node = input;
            return this;
        }
    }
}
