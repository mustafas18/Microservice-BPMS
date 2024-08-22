using BPMS.Domain.Events;
using BPMS.Domain.Interfaces;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using BPMSWebApp.Dtos;
using MediatR;
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
    public abstract class NodeBranchService : INodeBranchService
    {
        private readonly IRepository<Node> _nodeRepository;
        private readonly IMediator _mediator;

        public NodeBranchService(IRepository<Node> nodeRepository,
            IMediator mediator)
        {
            _nodeRepository = nodeRepository;
            _mediator = mediator;
        }
        protected NodeBranchService()
        {
            
        }
        public virtual bool IsMatch(Node node)
        {
            throw new NotImplementedException();
        }
        // The Run methid is the template method defines the skeleton of an algorithm.
        public async Task Run(Node node)
        {
           var executeResult = this.Execute(node);
            await _mediator.Publish(new NodeRanEvent(executeResult));
        }
        public async Task Run(NextNode nextNode)
        {
            var node = _nodeRepository.FirstOrDefault(n=>n.Id==nextNode.NodeId);
            var executeResult = this.Execute(node);
            await _mediator.Publish(new NodeRanEvent(executeResult));
        }
        // This operation have to be implemented in subclasses.
        public abstract NodeRunResult Execute(Node node);
    }
}
