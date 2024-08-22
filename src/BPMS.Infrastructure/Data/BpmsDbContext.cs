using BPMS.Domain.Entities;
using BpmsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace BPMS.Infrastructure
{
    public class BpmsDbContext: DbContext
    {
        public BpmsDbContext()
        {

        }
        public BpmsDbContext(DbContextOptions<BpmsDbContext> options) : base(options)
        {
        }


        public DbSet<Node> Nodes { get; set; }
        public DbSet<NextNode> NextNodes { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowTemplate> WorkflowTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
           
            modelBuilder.Entity<Node>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

            modelBuilder.Entity<WorkflowTemplate>()
                .HasQueryFilter(m =>  m.IsDeleted == false);

          
        }
    }

}

