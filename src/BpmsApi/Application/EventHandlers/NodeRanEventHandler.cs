using BPMS.Domain.Entities;
using BPMS.Domain.Enums;
using BPMS.Domain.Events;
using BPMS.Domain.Interfaces;
using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;

namespace Bpms.Api.Application.EventHandlers
{
    public class NodeRanEventHandler : INotificationHandler<NodeRanEvent>
    {
        private readonly INodeBranchService _nodeBranchService;
        private readonly IRepository<WorkflowFlow> _flowRepository;

        public NodeRanEventHandler(INodeBranchService nodeBranchService,
            IRepository<WorkflowFlow> flowRepository)
        {
            _nodeBranchService = nodeBranchService;
            _flowRepository = flowRepository;
        }
        public async Task Handle(NodeRanEvent notification, CancellationToken cancellationToken)
        {
            if (notification.NodeExecuteResult.GoNextNode)
            {
                var currentFlow = _flowRepository.FirstOrDefault(s => s.NodeId == notification.NodeExecuteResult.NodeId && s.WorkflowId == notification.NodeExecuteResult.WorkflowId);
                await _flowRepository.UpdateAsync(currentFlow.UpdateFlow(DateTime.Now,WorkflowStatusEnum.Completed));
               
                var flows=new List<WorkflowFlow>();
                Parallel.ForEach(notification.NodeExecuteResult.NextNodes, async node =>
                {
                    var flow = new WorkflowFlow(notification.NodeExecuteResult.WorkflowId, node.NodeId, DateTime.Now, WorkflowStatusEnum.InProgress);
                    flows.Add(flow);
                    _nodeBranchService.Run(node);
                });
                await _flowRepository.AddRangeAsync(flows);
            }

        }
    }
}
