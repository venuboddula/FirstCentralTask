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
        IEnumerable<IItem> _items;
        IEnumerable<SpecialOffer> _specialOffers;
        ICheckout _checkOut;
        public CheckoutTestShould()
        {
            _items = new List<Item>()
            {
                new Item() { SKU="A99", UnitPrice=0.50m },
                new Item() { SKU="B15", UnitPrice=0.30m },
                new Item() { SKU="C40", UnitPrice=0.60m }
            };
            _specialOffers = new List<SpecialOffer>() 
            {
                new SpecialOffer() { SKU = "A99", Quantity=3, OfferPrice = 1.20m },
                new SpecialOffer() { SKU = "B15", Quantity=2, OfferPrice = 0.45m }
            };

            _checkOut = new Checkout(_items, _specialOffers);
        }

        [Fact]

        public void Be_Able_To_Scan_An_Item()
        {
            //Assign
            IItem item = new Item() { SKU = "A99", UnitPrice = 0.50m };            

            //Act
            _checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Contains(_checkOut.CheckoutItems, x => x.Key.ToString() == item.SKU);
        }

        [Fact]

        public void Not_Scan_A_Null_Item()
        {
            //Assign  
            IItem item = null;

            //Act
            _checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Equal(0, _checkOut.CheckoutItems.Count);
        }

        [Fact]

        public void Not_Scan_An_Invalid_Item()
        {
            //Assign  
            IItem item = new Item() { SKU = "A97", UnitPrice = 0.50m };

            //Act
            _checkOut = _checkOut.Scan(item);

            //Assert
            Assert.Equal(0, _checkOut.CheckoutItems.Count);
        }

        [Fact]

        public void Be_Able_To_Calculate_The_Price_Of_ScannedItem()
        {
            //Assign  
            IItem item = new Item() { SKU = "A99", UnitPrice = 0.50m };

            //Act
            _checkOut = _checkOut.Scan(item);
            decimal total = _checkOut.Total();

            //Assert
            Assert.Equal(0.50m, total);
        }

        [Fact]

        public void Be_Able_To_Calculate_The_Price_Of_Multiple_ScannedItems()
        {
            //Assign  
            IEnumerable<IItem> items = new List<Item>()
            {
                new Item { SKU = "A99", UnitPrice = 0.50m },
                new Item { SKU = "B15", UnitPrice = 0.30m }
            };

            foreach(Item item in items)
            {
                _checkOut.Scan(item);
            }  

            //Act;
            decimal total = _checkOut.Total();

            //Assert
            Assert.Equal(0.80m, total);
        }

    }
}
