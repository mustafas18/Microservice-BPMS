

using BpmsDomain.Entities;

namespace BPMSDomain.Interfaces
{
    public interface IProcessService
    {
       void Execute(Node node);
    }
}
