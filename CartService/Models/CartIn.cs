using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models.EF
{
    public class CartIn
    {
        public string idClient { get; set; }
        public string idProduct { get; set; }
        public int  quantity { get; set; }
    }
}
