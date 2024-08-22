using BPMSDomain.Interfaces;
using System.Data;

namespace BPMSDomain.Services
{
    public class EvaluateConditionService : IEvaluateConditionService
    {
        public bool Evaluate(string nodeCondition, int formDataId)
        {
            var conditionVariables = new List<(string name, object value)>();
            return runWithVariables<bool>(nodeCondition, conditionVariables);
        }
        private TResult runWithVariables<TResult>(string formula,
            List<(string name, object value)> variables)
        {
            using DataTable table = new DataTable();

            foreach (var (n, v) in variables)
                table.Columns.Add(n, v is null ? typeof(object) : v.GetType());

            table.Rows.Add();

            foreach (var (n, v) in variables)
                table.Rows[0][n] = v;

            table.Columns.Add("__Result", typeof(double)).Expression = formula
              ?? throw new ArgumentNullException(nameof(formula));

            return (TResult)(Convert.ChangeType(table.Compute($"Min(__Result)", null), typeof(TResult)));
        }
    }
}
