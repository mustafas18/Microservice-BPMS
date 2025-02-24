﻿using BpmsApi.Enums;
using BpmsDomain.Entities;


namespace BPMS.Domain.Entities
{
    public class Node : BaseEntity<int>
    {
        public Node() { }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public NodeTypeEnum NodeType { get; private set; }
        public int WorkflowId { get; private set; }
        public List<NextNode>? NextNodes { get; private set; }
        public List<string>? Assignees { get; private set; }
        public List<string>? Departments { get; private set; }
        public int? FormId { get; private set; }
        public DateTime? TaskOverdue { get; private set; }
        public int? ScriptId { get; private set; }
        public int? EmailId { get; private set; }
        public string? StartIntermediateNodeCondition { get; private set; }

        public string? SignalKey { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int? PoolId { get; private set; }
        public string? PositionInPool { get; private set; }

    }
    public class NextNode
    {
        public int NodeId { get; set; }
        public string Condition { get; set; }

    }
}
