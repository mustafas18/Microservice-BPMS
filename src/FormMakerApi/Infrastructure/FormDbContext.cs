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
        public DbSet<ComponentValue> ElementValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormTemplate>().OwnsOne(
                form => form.Components, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });
            modelBuilder.Entity<FormData>().OwnsOne(
                form => form.ComponentDatas, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });


        

            modelBuilder.Entity<FormTemplate>()
                 .HasQueryFilter(m =>  m.IsDeleted==false);
           
            modelBuilder.Entity<Form>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

            modelBuilder.Entity<FormData>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

          
        }
    }

}

