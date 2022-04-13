using CheckoutKata.Library;
using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IItem> items = new List<Item>()
            {
                new Item() { SKU="A99", UnitPrice=0.50m },
                new Item() { SKU="B15", UnitPrice=0.30m },
                new Item() { SKU="C40", UnitPrice=0.60m }
            };

            Checkout checkOut = new Checkout(items);

            Item item1 = new Item { SKU = "A99", UnitPrice = 0.50m };
            checkOut.Scan(item1);
            Item item2 = new Item { SKU = "B15", UnitPrice = 0.30m };
            checkOut.Scan(item2);

            decimal total = checkOut.Total();
            Console.WriteLine($"Total price of items is {total}");
        }
    }
}
