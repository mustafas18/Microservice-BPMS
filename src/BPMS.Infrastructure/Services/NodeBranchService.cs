using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Infrastructure.Services
{
    /// <summary>
    // The Abstract Class NodeBranchService defines a template method that contains a skeleton of
    // some algorithm, composed of calls to (usually) abstract primitive
    // operations.
    //
    // Concrete subclasses should implement these operations, but leave the
    // template method itself intact.
    /// </summary>
    public abstract class NodeBranchService
    {
        public virtual bool IsMatch(Node node)
        {
            throw new NotImplementedException();
        }
        // The Run methid is the template method defines the skeleton of an algorithm.
        public void Run(Node node)
        {
            this.Execute(node);

        }
        // This operation have to be implemented in subclasses.
        public abstract NodeRunnerResult Execute(Node node);
    }
}
