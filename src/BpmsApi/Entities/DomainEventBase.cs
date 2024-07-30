using MediatR;

namespace BpmsApi.Entities
{
    public class DomainEventBase: INotification
        {
            public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
        }
    }