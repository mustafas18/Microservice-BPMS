

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class ManualTask : NodeBranchService
    {
        private readonly IRepository<Node> nodeRepository;
        private readonly IMediator mediator;

        public ManualTask(IRepository<Node> nodeRepository, IMediator mediator) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
        }
        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.ManualTask;
        }

        public override NodeRunResult Execute(Node node)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                foreach (var assignee in node.Assignees)
                {
                    // add manual task
                }
            }
            return new NodeRunResult(node.Id, node.NextNodes, false);
        }
        public NodeRunResult Submit(Node node)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                foreach (var assignee in node.Assignees)
                {
                    //TODO: if a assignee does not submit the form
                    //return new NodeRunResult(node.Id, node.NextNodes, false);
                }
            }
            
            return new NodeRunResult(node.Id, node.NextNodes, true);
        }
    }
}
