using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    interface ICartService
    {
        ActionResult AddToCart(string userId, string productId, int quantity);
        ActionResult GetById(string userId);
        ActionResult EmptyCart(string id);
               
    }
}
