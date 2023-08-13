using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculate.Service.Tax.DTO;

namespace TaxCalculate.Service.Tax.Infrastructure
{
    public interface ITaxService
    {
        public Task<int> CalculateTaxByVehicleAsync(SortedSet<DateTime> dateTimes, Vehicle vehicle);
    }
}
