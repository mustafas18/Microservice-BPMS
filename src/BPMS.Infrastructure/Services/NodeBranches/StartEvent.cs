

using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BpmsApi.Enums;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class StartEvent: NodeBranchService
    {
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.StartEvent;
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(StartEvent));
            return new NodeRunnerResult(node.Id, node.NextNodes, true);
        }
    }
}
