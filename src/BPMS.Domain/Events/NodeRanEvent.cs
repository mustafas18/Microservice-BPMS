using BPMSWebApp.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Events
{
    public class NodeRanEvent : INotification
    {

        public NodeRanEvent(NodeRunResult nodeExecuteResult)
        {
            NodeExecuteResult = nodeExecuteResult;
        }

        public NodeRunResult NodeExecuteResult { get; }
    }
}
