using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopBridge.Core
{
    public interface IProductCore
    {
        DataTable DoFetchProductDetails(string connString);
        int DoAddProduct(string connString, ProductModel jsondata);
        int DoUpdateProduct(string connString, ProductModel productItem);
        int DeleteProductByID(string connString, int productID);
    }
}
