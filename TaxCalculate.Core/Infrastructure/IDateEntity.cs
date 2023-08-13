using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculate.Core.Infrastructure

{
    public interface IDateEntity
    {
         DateTime CreateOn { get; set; }
         DateTime UpdateOn { get; set; }
    }
}
