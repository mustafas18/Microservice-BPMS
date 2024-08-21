using BPMSDomain.Interfaces;

namespace BPMSDomain.Services
{
    public class EvaluateConditionService : IEvaluateConditionService
    {
        public bool Evaluate(string nodeCondition, string actualCondition)
        {
            return nodeCondition == actualCondition;
        }
    }
}
