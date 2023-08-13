using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaxCalculate.Service.Tax.Common;
using TaxCalculate.Service.Tax.DTO;
using TaxCalculate.Service.Tax.Infrastructure;

namespace TaxCalculate.Service.Tax.Services
{
    public class TaxService : ITaxService
    {
        public async Task<int> CalculateTaxByVehicleAsync(SortedSet<DateTime> dateTimes, Vehicle vehicle)
        {
            try
            {
                #region create fake date
                var exemptDates = TaxHandler.CreateFakeExemptDate();
                var timePrices = TaxHandler.CreateFakeTimePrice();

                #endregion

                if (vehicle.IsExemptVehicle)
                {
                    return 0;
                }
                else
                {
                    foreach (DateTime date in dateTimes)
                    {
                        var isHoliday =await TaxHandler.IsHolidayAsync(date, exemptDates);
                        if (isHoliday)
                        {
                            return 0;
                        }
                    }
                    return await TaxHandler.CalculateFeeAsync(dateTimes, timePrices);
                }
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);

            }


        }
    }
}
