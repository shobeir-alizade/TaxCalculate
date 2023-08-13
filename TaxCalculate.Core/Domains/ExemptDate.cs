using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculate.Core.BaseClass;

namespace TaxCalculate.Core.Domains
{
    /// <summary>
    /// this table use for ExemptDate
    /// this table full by Administator
    /// </summary>
    public class ExemptDate : BaseEntity
    {

        /// <summary>
        /// just for Fake Data
        /// </summary>
        public ExemptDate()
        { 
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        /// <summary>
        /// if delete a record this field set to true
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// just for Fake Data
        /// </summary>
        public List<ExemptDate> ExemptDates;

    }
}
