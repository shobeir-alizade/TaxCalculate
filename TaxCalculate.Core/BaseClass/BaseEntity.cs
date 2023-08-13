using TaxCalculate.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculate.Core.BaseClass
{
    public  class BaseEntity:IEntity,IDateEntity
    {
        public int ID { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
