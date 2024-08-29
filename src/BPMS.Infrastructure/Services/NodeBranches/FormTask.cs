using Bpms.Domain.Proto;
using BPMS.Domain.Entities;
using BPMS.Domain.Enums;
using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using Grpc.Net.Client;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Shared;
using Shared.Config;
using GrpcFormClient = Bpms.Domain.Proto.FormServiceGrpc.FormServiceGrpcClient;
namespace BPMSInfrastructure.Services.NodeBranches
{
    public class FormTask : NodeBranchService
    {
        private readonly IRepository<Node> nodeRepository;
        private readonly IMediator mediator;
        private readonly IRepository<WorkflowHistory> _workflowHistoryRepository;
        private readonly IRepository<WorkflowFlow> _workflowFlowRepository;


        public FormTask(IRepository<Node> nodeRepository,
            IRepository<WorkflowHistory> workflowHistoryRepository,
            IRepository<WorkflowFlow> workflowFlowRepository,
            IMediator mediator) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
            _workflowHistoryRepository = workflowHistoryRepository;
            _workflowFlowRepository = workflowFlowRepository;
        }

        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.ManualTask;
        }


        public override async Task<NodeRunResult> Execute(Node node)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                var workflowHistorys = new List<WorkflowHistory>();
                foreach (var assignee in node.Assignees)
                {
                    if(node.FormId==null) { 
                        // TODO: error log..

                        continue;
                    }
                    var formId = node.FormId ?? 0;
                    // create formData
                    var channel = GrpcChannel.ForAddress(Endpoints.FormMakerEndpoint);
                    var grpcFormClient = new GrpcFormClient(channel);
                    var resp = await grpcFormClient.CreateFormDataAsync(
                        new GrpcRequest
                        {
                            AssigneeId = assignee,
                            FormId = formId,
                            NodeId = node.Id,
                        });
                    workflowHistorys.Add(new WorkflowHistory(node.WorkflowId, node.Id, assignee, resp.FormDataId, DateTime.Now, WorkflowStatusEnum.NotStarted));

                }
                await _workflowHistoryRepository.AddRangeAsync(workflowHistorys);
            }
            else if (!node.Departments.IsNullOrEmpty())
            {
                // find the department admin and assign form to him.
                // add formData
                // create formData
            }
            return new NodeRunResult(node.WorkflowId, node.Id, node.NextNodes, false);
        }
        public async Task<NodeRunResult> Submit(Node node, string assigneeId)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                var assignment = _workflowHistoryRepository.FirstOrDefault(s => s.WorkflowId == node.WorkflowId && s.NodeId == node.Id && s.AssigneeId == assigneeId && s.Status != WorkflowStatusEnum.Completed && s.Status != WorkflowStatusEnum.Canceled);
                if (assignment != null)
                {
                    var history = _workflowHistoryRepository.FirstOrDefault(x => x.WorkflowId == node.WorkflowId && x.NodeId == node.Id && x.AssigneeId == assigneeId);
                    history.UpdateStatus(WorkflowStatusEnum.Completed);
                    await _workflowHistoryRepository.UpdateAsync(history);
                    // update formData of assignee
                    // update variables via form outputvariable

                }
                foreach (var assignee in node.Assignees)
                {
                    var notCompleted = _workflowHistoryRepository.Where(s => s.WorkflowId == node.WorkflowId && s.NodeId == node.Id && s.AssigneeId == assignee && s.Status != WorkflowStatusEnum.Completed);
                    if (notCompleted.Any())
                    {
                        return new NodeRunResult(node.WorkflowId, node.Id, node.NextNodes, false);
                    }
                }
            }
            await _workflowFlowRepository.AddAsync(new WorkflowFlow(node.WorkflowId, node.Id, DateTime.Now, WorkflowStatusEnum.Completed));
            return new NodeRunResult(node.WorkflowId, node.Id, node.NextNodes, true);
        }
    }
}
