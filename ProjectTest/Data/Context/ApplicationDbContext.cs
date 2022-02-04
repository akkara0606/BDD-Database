using Microsoft.EntityFrameworkCore;
using ProjectTest.Data.Configuration;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Uploadfile> Uploadfiles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigConfiguration());
            modelBuilder.ApplyConfiguration(new UpfileConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());



        }
    }
}