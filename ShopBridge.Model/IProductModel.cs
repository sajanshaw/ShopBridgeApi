using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Model
{
    public interface IProductModel
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        int InStock { get; set; }
        

    }
}
