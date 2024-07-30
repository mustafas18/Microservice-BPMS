using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpmsApi.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public bool IsDeleted { get;protected set; }
        private List<DomainEventBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}
