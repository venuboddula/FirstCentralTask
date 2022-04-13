using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class Checkout: ICheckout
    {
        private readonly IEnumerable<IItem> _items;
        private readonly IEnumerable<SpecialOffer> _specialOffers;
        private readonly IDictionary<string, int> _checkoutItems;

        public IDictionary<string, int> CheckoutItems
        {
            get
            {
                return _checkoutItems;
            }
        }
        public Checkout(IEnumerable<IItem> items, IEnumerable<SpecialOffer> specialOffers)
        {
            _items = items;
            _specialOffers = specialOffers;
            _checkoutItems = new Dictionary<string, int>();
        }
        public ICheckout Scan(IItem item)
        {
            if (item != null)
            {
                //Check if a valid item is passed for scanning
                if(_items.Any(x=>x.SKU == item.SKU))
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
            }
            return this;
        }
        

        public decimal Total()
        {
            decimal total = 0;

            foreach (KeyValuePair<string, int> item in CheckoutItems)
            {
                total += CalulateItemTotal(item.Key, item.Value);

            }

            return total;
        }

        private decimal CalulateItemTotal(string sku, int itemCount)
        {
            decimal total = 0;

            if (ItemHasGotSpecialOffer(sku))
            {
                var specialItem = _specialOffers.Single(x => x.SKU == sku);
                var offerItems = itemCount / specialItem.Quantity;
                var unOfferItems = itemCount % specialItem.Quantity;
                total = (offerItems * specialItem.OfferPrice) + (unOfferItems * GetPriceForItem(sku));
            }
            else
            {
                total += GetPriceForItem(sku) * itemCount;
            }

            return total;
        }

        private decimal GetPriceForItem(string sku)
        {
            return _items.Single(x => x.SKU == sku).UnitPrice;

        }
        private bool ItemHasGotSpecialOffer(string sku)
        {
            return _specialOffers.Any(x => x.SKU == sku);
        }
    }
}
