

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class EndEvent: NodeBranchService
    {
        private readonly IRepository<Node> nodeRepository;
        private readonly IMediator mediator;

        public EndEvent(IRepository<Node> nodeRepository,
            IMediator mediator) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
        }
        public EndEvent()
        {
            
        }
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.EndEvent;
        }

        public override NodeRunResult Execute(Node node)
        {
            Console.WriteLine(nameof(EndEvent));
            return new NodeRunResult(node.Id, node.NextNodes,true);
        }
    }
}
