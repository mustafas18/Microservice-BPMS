

using BPMS.Domain.Entities;
using BPMS.Domain.Enums;
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
        private readonly IRepository<WorkflowHistory> _workflowHistoryRepository;
        private readonly IRepository<WorkflowFlow> _workflowFlowRepository;
        private readonly HttpClient httpClient;

        public FormTask(IRepository<Node> nodeRepository, IMediator mediator,
            IRepository<WorkflowHistory> workflowHistoryRepository,
            IRepository<WorkflowFlow> workflowFlowRepository,
            HttpClient httpClient) : base(nodeRepository, mediator)
        {
            this.nodeRepository = nodeRepository;
            this.mediator = mediator;
            _workflowHistoryRepository = workflowHistoryRepository;
            _workflowFlowRepository = workflowFlowRepository;
            this.httpClient = httpClient;
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
                    workflowHistorys.Add(new WorkflowHistory(node.WorkflowId, node.Id, assignee, DateTime.Now, WorkflowStatusEnum.NotStarted));
             var formId= node.FormId;
                        // add formData
                    // create formData
                }
                await _workflowHistoryRepository.AddRangeAsync(workflowHistorys);
            }
            else if (!node.Departments.IsNullOrEmpty())
            {
                // find the department admin and assign form to him.
                // add formData
                // create formData
            }
            return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, false);
        }
        public async Task<NodeRunResult> Submit(Node node,string assigneeId)
        {
            if (!node.Assignees.IsNullOrEmpty())
            {
                var assignment = _workflowHistoryRepository.FirstOrDefault(s => s.WorkflowId == node.WorkflowId && s.NodeId == node.Id && s.AssigneeId == assigneeId && s.Status != WorkflowStatusEnum.Completed && s.Status != WorkflowStatusEnum.Canceled);
                if (assignment != null)
                {
                    var history = _workflowHistoryRepository.FirstOrDefault(x => x.WorkflowId==node.WorkflowId && x.NodeId==node.Id && x.AssigneeId == assigneeId);
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
            return new NodeRunResult(node.WorkflowId,node.Id, node.NextNodes, true);
        }
    }
}
