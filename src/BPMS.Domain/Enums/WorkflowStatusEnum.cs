using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Domain.Enums
{
   public enum WorkflowStatusEnum : byte
    {
        NotStarted,
        InProgress,
        Completed,
        Canceled
    }
}
