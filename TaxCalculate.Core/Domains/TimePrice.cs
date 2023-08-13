using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculate.Core.BaseClass;

namespace TaxCalculate.Core.Domains
{
    /// <summary>
    /// This table use for sava Price by Time, City
    /// this table full by Administator
    /// </summary>
    public class TimePrice : BaseEntity
    {

        public TimePrice()
        {
    
        }

        public TimeSpan StratTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Int32 Price { get; set; }
        /// <summary>
        /// we can save some policy by city
        /// </summary>
        public Int32 CityId { get; set; }
        /// <summary>
        /// if delete a record this field set to true
        /// </summary>
        public bool IsDelete { get; set; }
      /// <summary>
      /// for generate fake data
      /// </summary>
        public List<TimePrice> TimePrices;

    }
}
