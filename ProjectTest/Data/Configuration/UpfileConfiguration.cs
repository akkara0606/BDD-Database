using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Configuration
{
    public class UpfileConfiguration : IEntityTypeConfiguration<Uploadfile>
    {
        public void Configure(EntityTypeBuilder<Uploadfile> builder)
        {
            builder.HasKey(x => x.FileID);
            builder.ToTable("UploadFile", "dbo");
            builder.Property(t => t.FileID).HasColumnName("FileID");
            builder.Property(t => t.FileName).HasColumnName("FileName");
            builder.Property(t => t.Description).HasColumnName("Description");
            builder.Property(t => t.FilePath).HasColumnName("FilePath");
            builder.Property(t => t.FileSize).HasColumnName("FileSize");
        }
    }
}