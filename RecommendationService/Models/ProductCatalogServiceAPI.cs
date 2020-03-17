using ProductCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecommendationService.Models
{
    public class ProductCatalogServiceAPI
    {
        private HttpClient products;
        private Task<HttpResponseMessage> responseMessage;
        private const string PRODUCTS_BASE_URL = "https://localhost:44357/api/";
        private const string PRODUCTS_PAGE = "ProductCatalogService?pageNumber=";
        private const string PRODUCTS_NAME = "ProductCatalogService?name=";
        private const string PRODUCTS_PRODUCT_ID = "ProductCatalogService/";

        public ProductCatalogServiceAPI()
        {
            products = new HttpClient();
            products.BaseAddress = new Uri(PRODUCTS_BASE_URL);
            responseMessage = null;
        }

        public ProductDTO GetById(string id)
        {
            responseMessage = products.GetAsync(PRODUCTS_PRODUCT_ID + id);
            responseMessage.Wait();
            var r = responseMessage.Result.Content.ReadAsAsync<ProductDTO>().Result;
            if(responseMessage.Result.StatusCode == System.Net.HttpStatusCode.OK)
                return r;
            return new ProductDTO();
        }

        public PageDTO GetPage(int? pageNumber, string name)
        {
            if (pageNumber.HasValue)
            {
                responseMessage = products.GetAsync(PRODUCTS_PAGE + 1);
                responseMessage.Wait();
                return responseMessage.Result.Content.ReadAsAsync<PageDTO>().Result;
            }
            responseMessage = products.GetAsync(PRODUCTS_NAME + name);
            responseMessage.Wait();
            var r = responseMessage.Result.Content.ReadAsAsync<PageDTO>().Result;
            if (responseMessage.Result.StatusCode == System.Net.HttpStatusCode.OK)
                return r;
            else
                return new PageDTO();
        }
    }
}
