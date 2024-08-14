using FormMakerApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FormMakerApi.Infrastructure
{
    public class FormDbContext: DbContext
    {
        public FormDbContext()
        {

        }
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {
        }


        public DbSet<FormTemplate> FormTemplates { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormData> FormDatas { get; set; }
        public DbSet<ElementValue> ElementValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormTemplate>().OwnsOne(
                form => form.Components, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });
            modelBuilder.Entity<FormData>().OwnsOne(
                form => form.ArcheType, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            var tenantId = root.GetValue<string>("TenantId");
        

            modelBuilder.Entity<FormTemplate>()
                 .HasQueryFilter(m => m.TenantId == new Guid(tenantId) && m.IsDeleted==false);
           
            modelBuilder.Entity<Form>()
                .HasQueryFilter(m => m.TenantId == new Guid(tenantId) && m.IsDeleted == false);

            modelBuilder.Entity<FormData>()
                .HasQueryFilter(m => m.TenantId == new Guid(tenantId) && m.IsDeleted == false);
        }
    }

}

