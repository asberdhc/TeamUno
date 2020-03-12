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
            Cart cart = new Cart {
                idClient = userId,
                idProduct = productId,
                quantity = quantity
                
            };
            Data data = new Data();
            if (data.AddtoCart(cart))
                return Ok();
            else
                return Ok("product not added to cart");
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(string userId)
        {
            List<Cart> cartList = new List<Cart>();
            Data data = new Data();
            cartList.AddRange(data.GetCartById(userId));
            return Ok(userId);
          //  throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("")]
        public ActionResult EmptyCart(string id)
        {
            Data data = new Data();

            if (data.EmptyCart(id))
                return Ok("Cart empty");
            else
                return Ok("Can´t empty cart");
        }
    }
}