using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogService.Models
{
    public class Price
    {

        public string CurrencyCode { get; set; }
        public int Units { get; set; }
        public int Nanos { get; set; }

    }
}
