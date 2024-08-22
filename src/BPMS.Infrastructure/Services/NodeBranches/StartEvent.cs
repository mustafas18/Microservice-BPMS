

using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BpmsApi.Enums;
using BPMSWebApp.Dtos;
using BPMSDomain.Interfaces;
using MediatR;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class StartEvent: NodeBranchService
    {
        private readonly IRepository<Node> nodeRepository;
        private readonly IMediator mediator;

        public StartEvent(IRepository<Node> nodeRepository,
            IMediator mediator) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
        }
        public StartEvent()
        {
            
        }
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.StartEvent;
        }

        public override NodeRunResult Execute(Node node)
        {
            Console.WriteLine(nameof(StartEvent));
            return new NodeRunResult(node.Id, node.NextNodes, true);
        }
    }
}
