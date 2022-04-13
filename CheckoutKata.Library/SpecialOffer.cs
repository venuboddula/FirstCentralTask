using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class SpecialOffer:ISpecialOffer
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }
    }
}
