using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculate.ViewModel

{
    public class Vehicle
    {
        /// <summary>
        /// this table use to Tax Exempt vehicles
        /// I guess this entity will get bigger
        /// For this reason, I have considered a table
        /// </summary>
        [Required, MaxLength(32)]
        public string? Caption { get; set; }
      
        public bool IsExemptVehicle { get; set; }

        /// <summary>
        /// if delete a record this field set to true
        /// </summary>
        public bool IsDelete { get; set; }

    }
}
