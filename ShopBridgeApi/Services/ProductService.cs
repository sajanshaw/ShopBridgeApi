using ShopBridge.Common;
using ShopBridge.Core;
using ShopBridge.Model;
using System.Data;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ShopBridgeApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCore _IProductCore;
        private readonly IProductModel _IProductModel;
        private readonly IConfiguration _IConfiguration;
        public ProductService(IProductCore objProductCore, IProductModel objProductModel, IConfiguration objIConfiguration)
        {
            _IProductCore = objProductCore;
            _IProductModel = objProductModel;
            _IConfiguration=objIConfiguration;
        }


        public JSONResponse DoFetchProductDetails()
        {
            JSONResponse objJSONResponse = new JSONResponse();

            string connString = _IConfiguration.GetConnectionString("MyConn");

            DataTable dtProduct = _IProductCore.DoFetchProductDetails(connString);
            objJSONResponse.jsondata = JsonConvert.SerializeObject(dtProduct);
            objJSONResponse.rowcount = dtProduct.Rows.Count;
            objJSONResponse.status = true;
            return objJSONResponse;

        }
        public JSONResponse DoAddProduct(ProductModel productItem)
        {
            JSONResponse objJSONResponse = new JSONResponse();

            string connString= _IConfiguration.GetConnectionString("MyConn");

            int response = _IProductCore.DoAddProduct(connString, productItem);
            objJSONResponse.status = response == 1 ? true : false;
            return objJSONResponse;
        }

        public JSONResponse DoUpdateProduct(ProductModel productItem)
        {
            JSONResponse objJSONResponse = new JSONResponse();

            string connString = _IConfiguration.GetConnectionString("MyConn");

            int response = _IProductCore.DoUpdateProduct(connString, productItem);
            objJSONResponse.status = response == 1 ? true : false;
            return objJSONResponse;
        }

        public JSONResponse DeleteProductByID(int productID)
        {
            JSONResponse objJSONResponse = new JSONResponse();

            string connString = _IConfiguration.GetConnectionString("MyConn");

            int response = _IProductCore.DeleteProductByID(connString, productID);
            objJSONResponse.status=response==1 ? true : false;
            return objJSONResponse;
        }
    }
}
