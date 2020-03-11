using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase, ICartService
    {
        [HttpGet]
        [Route("")]
        public ActionResult Quick200Response()
        {
            return Ok("Server Working");
        }


        [HttpPost]
        [Route("")]
        public ActionResult AddToCart(string userId, string productId, int quantity)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(string userId)
        {
            return Ok(userId);
          //  throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("")]
        public ActionResult EmptyCart()
        {
            throw new NotImplementedException();
        }
    }
}