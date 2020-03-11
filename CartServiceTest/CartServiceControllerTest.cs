using CartService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CartServiceTest
{
    [TestClass]
    public class CartServiceControllerTest
    {
        string userId, productId;
        int quantity;
        CartServiceController cartServiceControllerMock;

        [TestInitialize]
        private void InitializeTest()
        {
            userId = "";
            productId = "";
            quantity = 3;
            cartServiceControllerMock = new CartServiceController();
        }

        [TestMethod]
        public void AddToCart_AllParamsValid_Ok200()
        {
            //arrange
            int expected = 200;

            //act
            int actual = 0;
            try
            {
                var response = (OkResult)cartServiceControllerMock.AddToCart(userId, productId, quantity);
                actual = response.StatusCode;
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e);
            }

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToCart_AllParamsInvalid_Error()
        {
            //TBD
        }

        [TestMethod]
        public void GetById_ValidIdOneItemInTheCart_ValidCartObject()
        {
            //arrange
            //act
            //assert
        }

        [TestMethod]
        public void GetById_InvalidId_Error()
        {
            //TBD
        }

        [TestMethod]
        public void EmptyCart_None_Ok200()
        {
            //TBD
        }
    }
}
