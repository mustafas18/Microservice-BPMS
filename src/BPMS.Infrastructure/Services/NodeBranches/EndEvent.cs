

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class EndEvent: NodeBranchService
    {
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.EndEvent;
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(EndEvent));
            return new NodeRunnerResult(node.Id, node.NextNodes,true);
        }
    }
}
