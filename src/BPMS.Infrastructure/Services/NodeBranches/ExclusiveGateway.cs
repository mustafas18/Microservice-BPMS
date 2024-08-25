

using BPMS.Domain.Entities;
using BPMS.Domain.Enums;
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
        private readonly IRepository<WorkflowHistory> _workflowHistoryRepository; 
        private readonly IRepository<WorkflowFlow> _workflowFlowRepository;


        public ExclusiveGateway(IEvaluateConditionService evaluateGatwayCondition,
            IRepository<WorkflowHistory> _workflowHistoryRepository,
            IRepository<WorkflowFlow> workflowFlowRepository)
        {
            _evaluateGatwayCondition = evaluateGatwayCondition;
            _workflowHistoryRepository = _workflowHistoryRepository;
            _workflowFlowRepository = workflowFlowRepository;
        }
        public override bool IsMatch(Node node)
        {
            return (node.NodeType == NodeTypeEnum.ExclusiveDivergingGateway || node.NodeType == NodeTypeEnum.ExclusiveConvergingGateway);
        }

        public override async  Task<NodeRunResult> Execute(Node node)
        {
            await _workflowHistoryRepository.AddAsync(new WorkflowHistory(node.WorkflowId, node.Id, null, null, DateTime.Now, WorkflowStatusEnum.NotStarted));
            if (node.NextNodes != null)
            {
                foreach (var nextNode in node.NextNodes)
                {
                    if (_evaluateGatwayCondition.Evaluate(nextNode.Condition,node.FormId))
                    {
                        var history = _workflowHistoryRepository.FirstOrDefault(x => x.WorkflowId == node.WorkflowId && x.NodeId == node.Id);
                        history.UpdateStatus(WorkflowStatusEnum.Completed);
                        await _workflowHistoryRepository.UpdateAsync(history);
                        await _workflowFlowRepository.AddAsync(new WorkflowFlow(node.WorkflowId, node.Id, DateTime.Now, WorkflowStatusEnum.Completed));
                        return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, true);
                    }
                }
                return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, false);
            }

            return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, false);
        }
    }
}
