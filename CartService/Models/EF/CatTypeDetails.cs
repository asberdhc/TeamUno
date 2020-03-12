using System;
using System.Collections.Generic;

namespace CartService.Models.EF
{
    public partial class CatTypeDetails
    {
        public int IdTypeDetail { get; set; }
        public int IdType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
