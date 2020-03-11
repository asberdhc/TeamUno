using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogService.Models
{
    public class Page
    {

        public List<Product> Products { get; set; }
        public int TotalItems { get; set; }

    }
}
