using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public interface ISpecialOffer
    {
        string SKU { get; set; }
        int Quantity { get; set; }
        decimal OfferPrice { get; set; }
    }
}
