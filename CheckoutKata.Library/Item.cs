﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Library
{
    public class Item:IItem
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
