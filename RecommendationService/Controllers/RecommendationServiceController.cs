using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Models;
using RecommendationService.Models;

namespace RecomendationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendationServiceController : ControllerBase
    {
        ProductCatalogServiceAPI productsAPI;

        public RecomendationServiceController()
        {
            productsAPI = new ProductCatalogServiceAPI();
        }

        [HttpGet]
        [Route("")]
        public ActionResult Ok200ServerWorking()
        {
            return Ok("Server Working");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetRecomendation(string id)
        {
            try
            {
                //obtaint the information related with the product
                List<string> actualCategories = productsAPI.GetById(id).Categories;

                //obtaining total pages
                int totalPages = productsAPI.GetPage(1, "").TotalItems;

                //Looking for products with similar categories
                List<ProductDTO> recomendedProducts = new List<ProductDTO>();
                while (totalPages > 0)
                {
                    var actualPage = productsAPI.GetPage(totalPages--, "").Products;
                    List<ProductDTO> productsSameCategory = actualPage.Where(p => p.Categories.Contains(actualCategories[0])).ToList();
                    recomendedProducts.AddRange(productsSameCategory);
                }

                return Ok(recomendedProducts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}