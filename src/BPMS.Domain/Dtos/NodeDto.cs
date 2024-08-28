using BPMS.Domain.Entities;
using BpmsApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Dtos
{
    public class NodeDto
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public NodeTypeEnum NodeType { get;  set; }
        public int WorkflowId { get;  set; }
        public List<NextNode> NextNodes { get;  set; }
        public List<string>? Assignees { get;  set; }
        public List<string>? Departments { get;  set; }
        public int FormId { get;  set; }
        public DateTime TaskOverdue { get;  set; }
        public int ScriptId { get;  set; }
        public int EmailId { get;  set; }
        public string StartIntermediateNodeCondition { get;  set; }

        public string SignalKey { get;  set; }
        public int PositionX { get;  set; }
        public int PositionY { get;  set; }
        public int Width { get;  set; }
        public int Height { get;  set; }
        public int PoolId { get;  set; }
        public string PositionInPool { get;  set; }
        public void SetConectionAndCondition(List<NextNode> nextNodes)
        {
            NextNodes = nextNodes;
        }
    }
}
