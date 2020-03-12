using CartService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    interface ICartService
    {
        ActionResult AddToCart(Cart cart);
        ActionResult GetById(string userId);
        ActionResult EmptyCart(string id);
               
    }
}
