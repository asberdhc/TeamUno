using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase
    {
        [HttpGet]
        public ActionResult Quick200Response()
        {
            return Ok();
        }
        [HttpGet]
        public ActionResult Get(string userId)
        {


            return Ok();
        }
    }
}