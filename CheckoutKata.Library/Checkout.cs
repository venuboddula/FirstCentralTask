using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class Checkout
    {
        private readonly IEnumerable<Item> _items;
        public Checkout(IEnumerable<Item> items)
        {
            _items = items;
        }
        public bool Scan(Item item)
        {
            return true;
        }
    }
}
