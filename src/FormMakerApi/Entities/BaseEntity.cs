using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormMakerApi.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
                
        }
        public BaseEntity(string tenantId)
        {
            TenantId = tenantId;
        }
        [Required]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.Now;
        public bool IsDeleted { get; protected set; }
        public string? TenantId { get;protected set; }
        private List<DomainEventBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}

