﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreGB1.ViewModels
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int ItemsCount => Items?.Sum(x => x.Quantity) ?? 0;
    }
}
