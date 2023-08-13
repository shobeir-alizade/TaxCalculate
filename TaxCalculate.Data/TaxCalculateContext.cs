using TaxCalculate.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace TaxCalculate.Data
{
    public class TaxCalculateContext : DbContext
    {
        public TaxCalculateContext(DbContextOptions<TaxCalculateContext> options):base(options)
        {
            
        }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxCalculateContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}