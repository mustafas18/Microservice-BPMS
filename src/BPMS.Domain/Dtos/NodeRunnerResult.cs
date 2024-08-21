using BpmsDomain.Entities;
using BPMSWebApp.Entities;
using System.Runtime.CompilerServices;

namespace BPMSWebApp.Dtos
{
    public class NodeRunnerResult
    {
        public NodeRunnerResult()
        {
            
        }
        /// <summary>
        /// NodeRunnerResult
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="nextNodes">NexNode</param>
        /// <param name="isDone">is done</param>
        public NodeRunnerResult(int NodeId,List<NextNode>? nextNodes,bool isDone)
        {
            this.NodeId = NodeId;
            NextNodes = nextNodes;
            IsDone = isDone;
        }
        /// <summary>
        /// NodeRunnerResult
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="nextNodes">NexNode</param>
        /// <param name="isDone">is done</param>
        public NodeRunnerResult(int NodeId,bool isDone,string message)
        {
            this.NodeId = NodeId;
            IsDone = isDone;
            Message = message;
        }

        public int NodeId { get; }
        public List<NextNode>? NextNodes { get; }
        public bool IsDone { get; set; }  
        public string Message { get; set; }
    }
}
