using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class City : BaseEntity
    {

        [Required, MaxLength(32)]
        public string Caption { get; set; }

        /// <summary>
        /// if delete a record this field set to true
        /// </summary>
        public bool IsDelete { get; set; }

    }
}
