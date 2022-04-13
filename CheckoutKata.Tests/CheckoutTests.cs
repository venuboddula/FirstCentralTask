using CheckoutKata.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    public class CheckoutTestShould
    {
        public CheckoutTestShould()
        {
            IEnumerable<Item> items = new List<Item>()
            {
                new Item() { SKU="A99", UnitPrice=0.50m },
                new Item() { SKU="B15", UnitPrice=0.30m },
                new Item() { SKU="C40", UnitPrice=0.60m }
            };
        }

    }
}
