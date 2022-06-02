using ShopBridge.Common;
using ShopBridge.Model;
using System;

namespace ShopBridgeApi.Services
{
    public interface IProductService
    {
        JSONResponse DoFetchProductDetails();
        JSONResponse DoAddProduct(ProductModel productItem);
        JSONResponse DoUpdateProduct(ProductModel productItem);
        JSONResponse DeleteProductByID(int productID);
    }
}
