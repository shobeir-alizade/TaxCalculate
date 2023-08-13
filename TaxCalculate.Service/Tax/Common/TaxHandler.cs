using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculate.Core.Domains;

namespace TaxCalculate.Service.Tax.Common
{
    public static class TaxHandler
    {

        /// <summary>
        /// check dat that is Free day or no?
        /// return false if it is not holiday
        /// </summary>
        /// <param name="date"></param>
        /// <param name="exemptDates"></param>
        /// <returns></returns>
        public async static Task<bool> IsHolidayAsync(DateTime date, List<ExemptDate> exemptDates)
        {

            foreach (var exemptDateItem in exemptDates)
            {
                if (date.Ticks > exemptDateItem.Start.Ticks && date.Ticks < exemptDateItem.End.Ticks)
                {
                    return true;
                }

            }
            return false;

        }
        /// <summary>
        /// CalculateFee by fake data
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <param name="timePrices"></param>
        /// <returns></returns>
        public async static Task<int> CalculateFeeAsync(SortedSet<DateTime> dateTimes, List<TimePrice> timePrices)
        {
            TimePrice timePrice = new TimePrice();
            double tempMinutes = 0;
            SortedSet<Int32> tempPrice = new SortedSet<int>();
            Int32 totlaPrice = 0;
            foreach (DateTime date in dateTimes)
            {
                var price = timePrices.FirstOrDefault(x => x.StratTime < date.TimeOfDay && x.EndTime > date.TimeOfDay).Price;
                //if count of minutes between this time and last time more than 60m
                // A single charge rule applies in Gothenburg. Under this rule,
                // a vehicle that passes several tolling stations within 60 minutes
                // is only taxed once. The amount that must be paid is the highest one.
                if (date.TimeOfDay.TotalMinutes - tempMinutes < 60)
                {
                    if (tempPrice.Last() < price)
                    {
                        totlaPrice += price;
                        totlaPrice -= tempPrice.Last();
                    }
                    else
                    {
                        totlaPrice += tempPrice.Last();
                        totlaPrice -= price;
                    }
                }
                else
                {
                    totlaPrice += price;
                }
                tempMinutes = date.TimeOfDay.TotalMinutes;
                tempPrice.Add(price);
            }
            if (totlaPrice > 60) totlaPrice = 60;
            return totlaPrice;
        }



        #region CREATE FAKE DATA
        public static List<ExemptDate> CreateFakeExemptDate()
        {
            ExemptDate exemptDate = new ExemptDate();
            exemptDate.ExemptDates = new List<ExemptDate>();
            for (int i = 0; i < 20; i += 5)
            {
                exemptDate.ExemptDates.Add(new ExemptDate() { ID = i, Start = DateTime.Now.AddDays(i), End = DateTime.Now.AddDays(i + 1) });
            }
            return exemptDate.ExemptDates;

        }

        public static List<TimePrice> CreateFakeTimePrice()
        {
            var TimePrices = new List<TimePrice> { new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(6,0,0) ,
                EndTime = new TimeSpan(6, 30, 0),
                CityId = 1,
                Price=8
            },

            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(1,0,0) ,
                EndTime = new TimeSpan(3, 59, 0),
                CityId = 1,
                Price = 13,
            }
            ,
            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(4,0,0) ,
                EndTime = new TimeSpan(7, 59, 0),
                CityId = 1,
                Price = 17,
            },
            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(8,0,0) ,
                EndTime = new TimeSpan(11, 59, 0),
                CityId = 1,
                Price = 15,
            },
            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(12,0,0) ,
                EndTime = new TimeSpan(14, 59, 0),
                CityId = 1,
                Price = 7,
            },
            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(15,0,0) ,
                EndTime = new TimeSpan(17, 59, 0),
                CityId = 1,
                Price = 9,
            },
            new TimePrice()
            {
                ID = 1,
                StratTime = new TimeSpan(18,0,0) ,
                EndTime = new TimeSpan(23, 59, 0),
                CityId = 1,
                Price = 20,
            }
            };
            return TimePrices;

        }
        #endregion
    }
}
