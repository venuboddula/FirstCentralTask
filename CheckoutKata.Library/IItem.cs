using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public interface IItem
    {
        string SKU { get; set; }
        decimal UnitPrice { get; set; }
    }
}
