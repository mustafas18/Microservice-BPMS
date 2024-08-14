using System.ComponentModel.DataAnnotations;

namespace Identity.API.Models
{
    public class EmployeeRole: BaseEntity
    {
        public EmployeeRole()
        {
            
        }
        public EmployeeRole(int id, string name, Guid tenantId) : base(id, tenantId)
        {
            Name= name;
        }
        public string Name { get; set; }
    }
}
