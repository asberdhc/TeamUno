using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Models;

namespace RecomendationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomendationServiceController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetRecomendation(string id)
        {
            HttpClient recomendation = new HttpClient();
            recomendation.BaseAddress = new Uri("https://localhost:44357/api/ProductCatalogService?pageNumber=1");

            var response = recomendation.GetAsync("");
            response.Wait();
            var items = response.Result.Content.ReadAsAsync<PageDTO>();

            return Ok();
        }
    }
}