

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class ManualTask : NodeBranchService
    {
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.ManualTask;
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(ManualTask));
            return new NodeRunnerResult(node.Id, node.NextNodes, true);
        }
    }
}
