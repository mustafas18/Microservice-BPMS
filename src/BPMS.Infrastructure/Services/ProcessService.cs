using BPMS.Domain.Entities;
using BPMS.Infrastructure.Services;
using BPMSDomain.Interfaces;
using BPMSDomain.Services;
using BPMSInfrastructure.Services.NodeBranches;
using MediatR;

namespace BPMSInfrastructure.Services
{
    public class ProcessService : IProcessService
    {
        private readonly List<NodeBranchService> NodeBrances;
        private readonly IRepository<Node> nodeRepository;
        private readonly IRepository<WorkflowHistory> workflowHistoryRepository;
        private readonly IRepository<WorkflowFlow> flowRepository;
        private readonly IRepository<Workflow> workflowRepository;
        private readonly IMediator mediator;
        private readonly HttpClient httpClient;
        private readonly IScriptRunnerService _scriptRunnerService;
        private readonly IEvaluateConditionService _evaluateGatwayCondition;


        public ProcessService(IRepository<Node> nodeRepository,
            IRepository<WorkflowHistory> workflowHistoryRepository,
            IRepository<WorkflowFlow> flowRepository,
            IRepository<Workflow> workflowRepository,
            IMediator mediator,
            IScriptRunnerService scriptRunnerService,
            IEvaluateConditionService evaluateGatwayCondition)
        {
            NodeBrances = new List<NodeBranchService>
            {
                // Tasks
                new ManualTask(this.nodeRepository,this.workflowHistoryRepository,this.flowRepository,this.mediator),
                new FormTask(this.nodeRepository,this.workflowHistoryRepository,this.flowRepository,this.mediator),

                // Gateways
                new ExclusiveGateway(_evaluateGatwayCondition,this.workflowHistoryRepository,this.flowRepository),

                // Events
                new StartEvent(this.nodeRepository,this.workflowHistoryRepository,this.flowRepository,this.mediator),
                new EndEvent(this.nodeRepository,this.workflowHistoryRepository,this.flowRepository,this.workflowRepository,this.mediator),
            };
            this.nodeRepository = nodeRepository;
            this.workflowHistoryRepository = workflowHistoryRepository;
            this.flowRepository = flowRepository;
            this.workflowRepository = workflowRepository;
            this.mediator = mediator;
            _scriptRunnerService = scriptRunnerService;
            _evaluateGatwayCondition = evaluateGatwayCondition;
        }
        public void Execute(Node node)
        {
            NodeBrances.First(nb => nb.IsMatch(node)).Run(node);
        }
    }
}
