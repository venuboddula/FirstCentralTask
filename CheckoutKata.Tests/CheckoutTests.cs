using CheckoutKata.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutTestShould
    {
        IEnumerable<Item> items;
        public CheckoutTestShould()
        {
            items = new List<Item>()
            {
                new Item() { SKU="A99", UnitPrice=0.50m },
                new Item() { SKU="B15", UnitPrice=0.30m },
                new Item() { SKU="C40", UnitPrice=0.60m }
            };
        }

        [Fact]

        public void Be_Able_To_Scan_An_Item()
        {
            //Assign
            Item item = new Item() { SKU = "A99", UnitPrice = 0.50m };
            Checkout checkOut = new Checkout(items);

            //Act
            bool isScanned = checkOut.Scan(item);

            //Assert
            Assert.True(isScanned);
        }

    }
}
