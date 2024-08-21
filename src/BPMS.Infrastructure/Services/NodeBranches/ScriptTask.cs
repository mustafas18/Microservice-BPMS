

using BPMS.Infrastructure.Services;
using BpmsApi.Enums;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;

namespace BPMSInfrastructure.Services.NodeBranches
{
    public class ScriptTask : NodeBranchService
    {
        private readonly IScriptRunnerService _scriptRunnerService;

        public ScriptTask(IScriptRunnerService scriptRunnerService)
        {
            _scriptRunnerService = scriptRunnerService;
        }

        public override bool IsMatch(Node node)
        {
            return node.NodeType == NodeTypeEnum.ScriptTask;
        }

        public override NodeRunnerResult Execute(Node node)
        {
            Console.WriteLine(nameof(ScriptTask));
            var result=  _scriptRunnerService.RunScript(node.ScriptId);
            return new NodeRunnerResult(node.Id, node.NextNodes, result);
        }
    }
}
