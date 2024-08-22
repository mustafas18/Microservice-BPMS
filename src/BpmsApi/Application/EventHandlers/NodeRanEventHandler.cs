using BPMS.Domain.Events;
using BPMS.Domain.Interfaces;
using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BPMSWebApp.Dtos;
using MediatR;

namespace Bpms.Api.Application.EventHandlers
{
    public class NodeRanEventHandler : INotificationHandler<NodeRanEvent>
    {
        private readonly INodeBranchService _nodeBranchService;

        public NodeRanEventHandler(INodeBranchService nodeBranchService)
        {
            _nodeBranchService = nodeBranchService;
        }
        public Task Handle(NodeRanEvent notification, CancellationToken cancellationToken)
        {
            if (notification.NodeExecuteResult.GoNextNode)
            {
                Parallel.ForEach(notification.NodeExecuteResult.NextNodes, node =>
                {
                    _nodeBranchService.Run(node);
                });
            }

            return Task.CompletedTask;
        }
    }
}
