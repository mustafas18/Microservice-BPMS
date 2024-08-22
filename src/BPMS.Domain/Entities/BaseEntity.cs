using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpmsDomain.Entities
{
    public class BaseEntity<T> where T : struct
    {
        public BaseEntity()
        {
                
        }
        [Required]
        public T Id { get; set; }
        public bool IsDeleted { get;protected set; }
        public Guid TenantId { get; protected set; }
        private List<DomainEventBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}
