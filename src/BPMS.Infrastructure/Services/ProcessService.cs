using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
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
        private readonly IMediator mediator;
        private readonly IScriptRunnerService _scriptRunnerService;
        private readonly IEvaluateConditionService _evaluateGatwayCondition;


        public ProcessService(IRepository<Node> nodeRepository,
            IMediator mediator,
            IScriptRunnerService scriptRunnerService,
            IEvaluateConditionService evaluateGatwayCondition)
        {
            NodeBrances = new List<NodeBranchService>
        {
            // Tasks
            new ManualTask(this.nodeRepository,this.mediator),
            new FormTask(this.nodeRepository,this.mediator),

            // Gateways
            new ExclusiveGateway(_evaluateGatwayCondition ?? new EvaluateConditionService()),

            // Events
            new StartEvent(this.nodeRepository,this.mediator),
            new EndEvent(this.nodeRepository,this.mediator),
        };
            this.nodeRepository = nodeRepository;
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
