 using TaxCalculate.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculate.Data.Mapping
{
    public class UserRefreshTokenHistoryMap : IEntityTypeConfiguration<UserRefreshTokenHistory>
    {
        public void Configure(EntityTypeBuilder<UserRefreshTokenHistory> builder)
        {

            builder.Property(p => p.CreateOn).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");
              
        }
    }
}
