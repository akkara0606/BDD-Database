using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Configuration
{
    public class ConfigConfiguration : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.HasKey(x => x.ConfigCode);
            builder.ToTable("Config", "dbo");
            builder.Property(t => t.ConfigSystem).HasColumnName("ConfigSystem");
            builder.Property(t => t.ConfigType).HasColumnName("ConfigType");
            builder.Property(t => t.ConfigCode).HasColumnName("ConfigCode");
            builder.Property(t => t.ConfigDescript).HasColumnName("ConfigDescript");
        }
    }
}