using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartService.Interfaces;
using CartService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase, ICartService
    {
        private RedisSource cache;

        public CartServiceController(bool mock = false)
        {
            if (mock)
                cache = new CartOnRedisMock();
            else
                cache = new CartOnRedis(Environment.GetEnvironmentVariable("cache_redis_server"));
        }
   
        [HttpGet]
        [Route("")]
        public ActionResult Quick200Response()
        {
            return Ok("Server Working");
        }

        [HttpPost]
        [Route("")]
        public ActionResult AddToCart([FromBody] CartIn cartFromBody)
        {
            if (cache.AddToCart(cartFromBody.idClient, cartFromBody.idProduct, cartFromBody.quantity))
                return Ok("The product has been added to cart");
            else
                return Ok("product not added to cart");
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult GetById(string userId)
        {
            return Ok(cache.GetById(userId));
        }

        [HttpDelete]
        [Route("{userId}")]
        public ActionResult EmptyCart(string userId)
        {
            if (cache.EmptyCart(userId))
                return Ok("Cart empty");
            else
                return Ok("Can´t empty cart");
        }
    }
}