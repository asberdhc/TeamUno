using System;
using System.Collections.Generic;

namespace CartService.Models.EF
{
    public partial class SizeForProduct
    {
        public int IdSizeProduct { get; set; }
        public int IdProduct { get; set; }
        public int IdSize { get; set; }

        public Products IdProductNavigation { get; set; }
        public CatSizes IdSizeNavigation { get; set; }
    }
}
