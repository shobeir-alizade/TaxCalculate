 using TaxCalculate.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculate.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            


            builder.Ignore(p => p.FullName);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property("Code").HasColumnType("nvarchar(50)");


            builder.Property(p => p.CreateOn).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");

            builder.HasIndex(p =>p.UserName);

            builder.HasCheckConstraint("CheckID", "ID>10");

            builder.Property(p => p.LastName).HasColumnType("Char(10)").HasConversion(p => p.ToString(), p => "dear " + p.ToString());


              
        }
    }
}
