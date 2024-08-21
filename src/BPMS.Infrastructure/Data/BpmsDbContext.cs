using BpmsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace BPMSDomain.Infrastructure
{
    public class FormDbContext: DbContext
    {
        public FormDbContext()
        {

        }
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {
        }


        public DbSet<Node> Nodes { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           
            modelBuilder.Entity<Node>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

            modelBuilder.Entity<Workflow>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

          
        }
    }

}

