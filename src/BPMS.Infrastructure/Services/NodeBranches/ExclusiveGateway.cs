

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using System.Xml.Linq;

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

        public override NodeRunResult Execute(Node node)
        {
            Console.WriteLine(nameof(ExclusiveGateway));
            if (node.NextNodes != null)
            {
                foreach (var nextNode in node.NextNodes)
                {
                    if (_evaluateGatwayCondition.Evaluate(nextNode.Condition,node.FormId))
                    {
                        return new NodeRunResult(node.Id, node.NextNodes, true);
                    }
                }
                return new NodeRunResult(node.Id, node.NextNodes, false);
            }

            return null;
        }
    }
}
