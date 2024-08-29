using BPMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Dtos
{
    public class WorkflowTemplateDto
    {
        public int? Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public List<Node>? Nodes { get;  set; }
    }
}
