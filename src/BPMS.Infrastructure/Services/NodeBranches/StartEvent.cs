

using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BpmsApi.Enums;
using BPMSWebApp.Dtos;
using BPMSDomain.Interfaces;
using MediatR;
using BPMS.Domain.Entities;
using BPMS.Domain.Enums;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class StartEvent: NodeBranchService
    {
        private readonly IRepository<Node> _nodeRepository;
        private readonly IRepository<WorkflowHistory> _workflowHistoryRepository;
        private readonly IRepository<WorkflowFlow> _flowRepository;
        private readonly IMediator _mediator;

        public StartEvent(IRepository<Node> nodeRepository,
             IRepository<WorkflowHistory> workflowHistoryRepository,
            IRepository<WorkflowFlow> flowRepository,
            IMediator mediator) : base(nodeRepository, mediator)
        {
            _nodeRepository = nodeRepository;
            _workflowHistoryRepository = workflowHistoryRepository;
            _flowRepository = flowRepository;
            _mediator = mediator;
        }
        public StartEvent()
        {
            
        }
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.StartEvent;
        }

        public override async Task<NodeRunResult> Execute(Node node)
        {
            await _workflowHistoryRepository.AddAsync(new WorkflowHistory(node.WorkflowId, node.Id,null, null, DateTime.Now, WorkflowStatusEnum.Completed));
            await _flowRepository.AddAsync(new WorkflowFlow(node.WorkflowId,node.Id,DateTime.Now,WorkflowStatusEnum.Completed));
            return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, true);
        }
    }
}
