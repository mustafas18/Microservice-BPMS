namespace BPMSDomain.Interfaces
{
    public interface IEvaluateConditionService
    {
        bool Evaluate(string nodeCondition,int formDataId);
    }
}
