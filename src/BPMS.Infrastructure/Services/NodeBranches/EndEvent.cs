

using BPMS.Domain.Entities;
using BPMS.Domain.Enums;
using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;
using Microsoft.Identity.Client;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class EndEvent: NodeBranchService
    {
        private readonly IRepository<Node> _nodeRepository;
        private readonly IRepository<WorkflowHistory> _workflowHistoryRepository;
        private readonly IRepository<WorkflowFlow> _flowRepository;
        private readonly IRepository<Workflow> _workflowRepository;
        private readonly IMediator _mediator;

        public EndEvent(IRepository<Node> nodeRepository,
            IRepository<WorkflowHistory> workflowHistoryRepository,
            IRepository<WorkflowFlow> flowRepository,
            IRepository<Workflow> workflowRepository,
            IMediator mediator) : base(nodeRepository, mediator)
        {
            _nodeRepository = nodeRepository;
            _workflowHistoryRepository = workflowHistoryRepository;
            _flowRepository = flowRepository;
            _workflowRepository = workflowRepository;
            _mediator = mediator;
        }
        public EndEvent()
        {
            
        }

       

        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.EndEvent;
        }

        public override async Task<NodeRunResult> Execute(Node node)
        {
            await _workflowHistoryRepository.AddAsync(new WorkflowHistory(node.WorkflowId, node.Id, null, null, DateTime.Now, WorkflowStatusEnum.Completed));
            await _flowRepository.AddAsync(new WorkflowFlow(node.WorkflowId, node.Id, DateTime.Now, WorkflowStatusEnum.Completed));
           var workflow =_workflowRepository.FirstOrDefault(s=>s.Id==node.WorkflowId);
            workflow = workflow.UpdateStatus(WorkflowStatusEnum.Completed);
            await _workflowRepository.UpdateAsync(workflow);
            return new NodeRunResult(node.WorkflowId, node.Id, null, true);
        }
    }
}
