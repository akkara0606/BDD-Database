using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Employee_id);
            builder.ToTable("Employee", "dbo");
            builder.Property(t => t.Emp_Password).HasColumnName("Emp_Password");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Surename).HasColumnName("Surename");
            builder.Property(t => t.Contact_number).HasColumnName("Contact");
        }
    }
}