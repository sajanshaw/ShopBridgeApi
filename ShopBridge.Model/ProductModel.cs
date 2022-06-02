﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Model
{
    public class ProductModel : IProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
