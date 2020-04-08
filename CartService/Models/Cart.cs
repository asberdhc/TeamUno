using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class Cart
    {
        public string idClient { get; set; }
        public List<Item> Items { get; set; }

    }
}
