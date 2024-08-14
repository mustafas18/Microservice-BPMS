using Identity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Identity.API.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Identity.API' project directory:
///
/// dotnet ef migrations add [migration-name]
/// </remarks>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<EmployeeRole>()
            .HasData(
            new EmployeeRole(1,"CEO", new Guid("abd71ab9-381d-4075-b80e-82639a85f789")),
                new EmployeeRole(2, "HR", new Guid("abd71ab9-381d-4075-b80e-82639a85f789")),
                new EmployeeRole(2, "EE", new Guid("abd71ab9-381d-4075-b80e-82639a85f789"))
            );
        var departmentId = Guid.NewGuid();
        builder.Entity<Department>()
            .HasData(
                new Department(1, departmentId, "Department of Science and Technology", "en"),
                new Department(2, departmentId, "دپارتمان علوم و تکنولوژی", "fa")
                );
    }
}
