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
        IEnumerable<Item> _items;
        Checkout _checkOut;
        public CheckoutTestShould()
        {
            _items = new List<Item>()
            {
                new Item() { SKU="A99", UnitPrice=0.50m },
                new Item() { SKU="B15", UnitPrice=0.30m },
                new Item() { SKU="C40", UnitPrice=0.60m }
            };

            _checkOut = new Checkout(_items);
        }

        [Fact]

        public void Be_Able_To_Scan_An_Item()
        {
            //Assign
            Item item = new Item() { SKU = "A99", UnitPrice = 0.50m };            

            //Act
            Checkout checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Contains(checkOut.CheckoutItems, x => x.Key.ToString() == item.SKU);
        }

        [Fact]

        public void Not_Scan_A_Null_Item()
        {
            //Assign  
            Item item = null;

            //Act
            Checkout checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Equal(0, checkOut.CheckoutItems.Count);
        }

        [Fact]

        public void Not_Scan_An_Invalid_Item()
        {
            //Assign  
            Item item = new Item() { SKU = "A97", UnitPrice = 0.50m };

            //Act
            Checkout checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Equal(0, checkOut.CheckoutItems.Count);
        }

        [Fact]

        public void Be_Able_To_Calculate_The_Price_Of_ScannedItem()
        {
            //Assign  
            Item item = new Item() { SKU = "A99", UnitPrice = 0.50m };

            //Act
            Checkout checkOut = _checkOut.Scan(item);
            decimal total = checkOut.Total();

            //Assert
            Assert.Equal(0.50m, total);
        }

    }
}
