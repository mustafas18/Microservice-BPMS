

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class FormTask: NodeBranchService
    {
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.ManualTask;
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(FormTask));
            return new NodeRunnerResult(node.Id, node.NextNodes, true);
        }
        public void SubmitTask()
        {
            throw new NotImplementedException();
        }
    }
}
