
namespace eShop.Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        //public EmployeeRole EmployeeRole { get; set; }
        public string TenantId { get; set; }
    }
}
