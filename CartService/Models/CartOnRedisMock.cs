using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class CartOnRedisMock : RedisSource
    {
        public CartOnRedisMock() : base("")
        {

        }

        public override bool AddToCart(string idClient, string idProduct, int quantity)
        {
            throw new NotImplementedException();
        }

        public override Item DeleteFromCart(string idClient, string idProduct, int quantity)
        {
            throw new NotImplementedException();
        }

        public override bool EmptyCart(string clientId)
        {
            throw new NotImplementedException();
        }

        public override Cart GetById(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
