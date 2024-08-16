using FormMaker.Entities;
using FormMakerApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DbSet<FormComponent> FormComponents { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormData>().OwnsOne(
                form => form.ComponentDatas, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
                });

            modelBuilder.Entity<FormComponent>().OwnsOne(
               c => c.InputValue, ownedNavigationBuilder =>
               {
                   ownedNavigationBuilder.ToJson();
            });

            modelBuilder.Entity<FormComponent>().OwnsOne(
                c => c.Values, ownedNavigationBuilder =>
                {
                    ownedNavigationBuilder.ToJson();
            });

           
            modelBuilder.Entity<Form>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

            modelBuilder.Entity<FormData>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

          
        }
    }

}

