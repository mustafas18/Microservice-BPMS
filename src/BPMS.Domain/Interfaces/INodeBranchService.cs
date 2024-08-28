using BPMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Interfaces
{
    public interface INodeBranchService
    {
        bool IsMatch(Node node);
        Task Run(Node node);
        Task Run(NextNode nextNode);
    }
}
