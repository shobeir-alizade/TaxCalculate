using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculate.Core.Domains
{
    public class ExemptVehicle
    {
        /// <summary>
        /// this table use to Tax Exempt vehicles
        /// I guess this entity will get bigger
        /// For this reason, I have considered a table
        /// </summary>
        public virtual int VehicleId{ get; set; }

        /// <summary>
        /// if delete a record this field set to true
        /// </summary>
        public bool IsDelete { get; set; }

    }
}
