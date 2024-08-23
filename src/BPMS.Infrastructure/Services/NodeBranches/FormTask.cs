

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class FormTask : NodeBranchService
    {
        private readonly IRepository<Node> nodeRepository;
        private readonly IMediator mediator;
        private readonly HttpClient httpClient;

        public FormTask(IRepository<Node> nodeRepository, IMediator mediator,
            HttpClient httpClient) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
            this.httpClient = httpClient;
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
                    // add formData
                    // create formData
                }
            }
            return new NodeRunResult(node.Id, node.NextNodes, false);
        }
        public NodeRunResult Submit(Node node,string assigneeId)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                //TODO: if a assignee does not submit the form
                // update formData of assignee
                // update variables via form outputvariable

                foreach (var assignee in node.Assignees)
                {
                    // if not submit exists
                        //return new NodeRunResult(node.Id, node.NextNodes, false);
                }
            }

            return new NodeRunResult(node.Id, node.NextNodes, true);
        }
    }
}
