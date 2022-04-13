using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public interface ICheckout
    {
        IDictionary<string, int> CheckoutItems { get; }
        Checkout Scan(IItem item);
        decimal Total();
    }
}
