using TaxCalculate.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculate.Data.Mapping
{
    public class UserRefreshTokenMap : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {

            builder.Property(p => p.CreateOn).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");
        }
    }
}
