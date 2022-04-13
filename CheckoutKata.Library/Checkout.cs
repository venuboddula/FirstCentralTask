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
        private readonly IDictionary<string, int> _checkoutItems;

        public IDictionary<string, int> CheckoutItems
        {
            get
            {
                return _checkoutItems;
            }
        }
        public Checkout(IEnumerable<Item> items)
        {
            _items = items;
            _checkoutItems = new Dictionary<string, int>();
        }
        public Checkout Scan(Item item)
        {
            if (item != null)
            {
                if (!CheckoutItems.ContainsKey(item.SKU))
                {
                    CheckoutItems.Add(item.SKU, 1);
                }
                else
                {
                    CheckoutItems[item.SKU]++;
                }
            }
            return this;
        }
    }
}
