using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.No);
            builder.ToTable("Document", "dbo");
            builder.Property(t => t.No).HasColumnName("No");
            builder.Property(t => t.RQE).HasColumnName("RQE");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Nameproj).HasColumnName("Nameproj");
            builder.Property(t => t.Department).HasColumnName("Department");
            builder.Property(t => t.Responsible).HasColumnName("Responsible");
            builder.Property(t => t.Locker).HasColumnName("Locker");
            builder.Property(t => t.Tdate).HasColumnName("Tdate");
            builder.Property(t => t.Year).HasColumnName("Year");
            builder.Property(t => t.Uploader).HasColumnName("Uploader");
            
        }
    }
}