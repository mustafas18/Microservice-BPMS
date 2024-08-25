using BpmsDomain.Entities;
using System.Runtime.CompilerServices;

namespace BPMSWebApp.Dtos
{
    public class NodeRunResult
    {
        public NodeRunResult()
        {
            
        }
        /// <summary>
        /// NodeRunnerResult
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="nextNodes">NexNode</param>
        /// <param name="goNextNode">is done and go to next nodes</param>
        public NodeRunResult(int workflowId,int nodeId,List<NextNode>? nextNodes,bool goNextNode)
        {
            WorkflowId = workflowId;
            this.NodeId = nodeId;
            NextNodes = nextNodes;
            GoNextNode = goNextNode;
        }
        public int WorkflowId { get; }
        public int NodeId { get; }
        public List<NextNode>? NextNodes { get; }
        public bool GoNextNode { get; set; } 
    }
}
