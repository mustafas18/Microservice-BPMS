

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class ExclusiveGateway : NodeBranchService
    {
        private readonly IEvaluateConditionService _evaluateGatwayCondition;
        public ExclusiveGateway(IEvaluateConditionService evaluateGatwayCondition)
        {
            _evaluateGatwayCondition = evaluateGatwayCondition;
        }
        public override bool IsMatch(Node node)
        {
            return (node.NodeType == NodeTypeEnum.ExclusiveDivergingGateway || node.NodeType == NodeTypeEnum.ExclusiveConvergingGateway);
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(ExclusiveGateway));
            if (node.NextNodes != null)
            {
                foreach (var nextNode in node.NextNodes)
                {
                    if (_evaluateGatwayCondition.Evaluate(nextNode.NodeCondition, "x=y"))
                    {
                        return new NodeRunnerResult(node.Id,new List<Node> { nextNode }, true);
                    }
                }
            }

            return null;
        }
    }
}
