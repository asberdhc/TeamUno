using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartService.Interfaces;
using CartService.Models;
using CartService.Models.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase, ICartService
    {
        private DataProductsContext db;
        public CartServiceController(DataProductsContext db)
        {
            this.db = db;
        }


        [HttpGet]
        [Route("")]
        public ActionResult Quick200Response()
        {
            return Ok("Server Working");
        }


        [HttpPost]
        [Route("")]
        
        public ActionResult AddToCart([FromBody] Cart cartFromBody)
        {
            Cart cart = new Cart {
                idClient = cartFromBody.idClient,
                idProduct = cartFromBody.idProduct,
                quantity = cartFromBody.quantity
                
            };
            Data data = new Data(db);
            if (data.AddtoCart(cart))
                return Ok("The product has been added to cart");
            else
                return Ok("product not added to cart");
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult GetById(string userId)
        {
            List<Cart> cartList = new List<Cart>();
            Data data = new Data(db);
            cartList.AddRange(data.GetCartById(userId));
            if (cartList.Count == 0 || cartList == null)
                return Ok("Empty cart");
            return Ok(cartList);
          //  throw new NotImplementedException();
        }
        [HttpDelete]
        [Route("{userId}")]
        public ActionResult EmptyCart(string userId)
        {
            Data data = new Data(db);

            if (data.EmptyCart(userId))
                return Ok("Cart empty");
            else
                return Ok("Can´t empty cart");
        }
    }
}