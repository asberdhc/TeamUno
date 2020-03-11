using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogService.Interfaces;
using ProductCatalogService.Models;

namespace ProductCatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogServiceController : ControllerBase, ICatalog

    {

        private DataProductsContext db;
        
        //NumPages
        public ActionResult GetPage(int pageNumber)
        {
            return Ok();
        }
        
        public ActionResult PostProduct(Product product)
        {
            return Ok();
        }

        public ActionResult PutProduct(Product product)
        {
            return Ok();
        }

        public ActionResult Delete(string id)
        {
            return Ok();
        }

        public ActionResult GetById(string id)
        {
            //regresa un metodo Ok()
            return Ok();
        }

        public ActionResult GetByName (string name)
        {
            return Ok();
        }

    }
}