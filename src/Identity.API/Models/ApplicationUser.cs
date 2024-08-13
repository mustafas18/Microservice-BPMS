using Identity.API.Models;

namespace eShop.Identity.API.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public Department Department { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public int TenantId { get; set; }
    }
}
