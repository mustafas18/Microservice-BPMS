using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using Variables.API.Models;
using Variables.Entities;

namespace BpmsVariables.Infrastructure
{
    public class VariablesDbContext: DbContext
    {
        public VariablesDbContext()
        {

        }
        public VariablesDbContext(DbContextOptions<VariablesDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Variable> Variables { get; set; }
      
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
          
        }
    }

}

