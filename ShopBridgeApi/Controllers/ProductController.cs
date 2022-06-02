using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Common;
using ShopBridge.Model;
using ShopBridgeApi.Services;

namespace ShopBridgeApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _IProductService;
        public ProductController(IProductService onjProductService)
        {
            _IProductService = onjProductService;
        }
        [HttpGet]
        public JSONResponse GetProductList()
        {
            JSONResponse objJSONResponse = new JSONResponse();
            objJSONResponse = _IProductService.DoFetchProductDetails();
            return objJSONResponse;
        }
        [HttpPost]
        public JSONResponse AddProduct(JSONRequestGeneric<ProductModel> obj)
        {
            JSONResponse objJSONResponse = new JSONResponse();
            objJSONResponse = _IProductService.DoAddProduct(obj.jsondata);
            return objJSONResponse;
        }
        [HttpPut]
        public JSONResponse UpdateProductByID(JSONRequestGeneric<ProductModel> obj)
        {
            JSONResponse objJSONResponse = new JSONResponse();
            objJSONResponse = _IProductService.DoUpdateProduct(obj.jsondata);
            return objJSONResponse;
        }
        [HttpDelete("{ID}")]
        public JSONResponse DeleteProductByID(int ID)
        {
            JSONResponse objJSONResponse = new JSONResponse();
            objJSONResponse = _IProductService.DeleteProductByID(ID);
            return objJSONResponse;
        }
    }
}
