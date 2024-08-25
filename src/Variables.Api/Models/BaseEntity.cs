using System.ComponentModel.DataAnnotations;

namespace Variables.API.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
                
        }
        public BaseEntity(int id,  Guid tenantId)
        {
            Id = id;
            TenantId = tenantId;
        }

        [Required]
        public int Id { get; set; }
        public Guid TenantId { get; set; }
    }
}
