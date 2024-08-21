

using BPMS.Infrastructure.Services;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSDomain.Services;
using BPMSInfrastructure.Services.NodeBranches;

namespace BPMSInfrastructure.Services
{
    public class ProcessService : IProcessService
    {
        private readonly List<NodeBranchService> NodeBrances;
        private readonly IScriptRunnerService _scriptRunnerService;
        private readonly IEvaluateConditionService _evaluateGatwayCondition;


        public ProcessService(IScriptRunnerService scriptRunnerService,
            IEvaluateConditionService evaluateGatwayCondition,
            IScriptRunnerService scriptRunner)
        {
            NodeBrances = new List<NodeBranchService>
        {
            // Tasks
            new ManualTask(),
            new FormTask(),
            new ScriptTask(_scriptRunnerService),

            // Gateways
            new ExclusiveGateway(_evaluateGatwayCondition ?? new EvaluateConditionService()),

            // Events
            new StartEvent(),
            new EndEvent(),
        };
            _scriptRunnerService = scriptRunnerService;
            _evaluateGatwayCondition = evaluateGatwayCondition;
        }
        public void Execute(Node node)
        {
            NodeBrances.First(nb => nb.IsMatch(node)).Run(node);
        }
    }
}
