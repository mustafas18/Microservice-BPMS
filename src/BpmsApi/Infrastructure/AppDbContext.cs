using BpmsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BpmsApi.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Node> Nodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>().OwnsOne(
                node => node.NextNodes, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });
            modelBuilder.Entity<Node>().OwnsOne(
               node => node.FormVariableMapper, ownedNavigationBuilder =>
               {
                   ownedNavigationBuilder.ToJson();
               });
        }
    }
}
