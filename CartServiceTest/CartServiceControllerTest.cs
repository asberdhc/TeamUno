using CartService.Controllers;
using CartService.Models;
using CartService.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace CartServiceTest
{
    [TestClass]
    public class CartServiceControllerTest
    {
       
        CartServiceController cartServiceControllerMock = new CartServiceController(new CartContextMock());

       
        [TestMethod]
        public void AddToCart_AllParamsValid_Ok200()
        {
            //arrange
            int expected = 200;
            Cart cart = new Cart{
                idClient ="14",
                idProduct = "563",
                quantity = 2
            }; 
            
            //act
            int? actual = 0;
            try
            {
                var response = (OkObjectResult)cartServiceControllerMock.AddToCart(cart);
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
        public void GetById_ValidIdOneItemInTheCart_ValidCartObject()
        {
            //arrange
            string Userid = "1";
            int expectedCountItems = 3;
            //act
            var response = (OkObjectResult)cartServiceControllerMock.GetById(Userid);
            //requestStatusCode = response.;
            var count = (int)response.Value.GetType().GetProperty("Count").GetValue(response.Value);
            //assert
            Assert.AreEqual(expectedCountItems, 3);
        }

    

        [TestMethod]
        public void GetById_InvalidId_Error()
        {
            //arrange
            string Userid = "gew", expectedMessage = "Empty cart";
            //act
            var response = (OkObjectResult)cartServiceControllerMock.GetById(Userid);
            //assert
            Assert.AreEqual(expectedMessage, response.Value);
            //TBD
        }

        [TestMethod]
        public void EmptyCart_None_Ok200()
        {
            //arrange
            string Userid = "1";
            string expectedMessage = "Cart empty";
            //act
            var response = (OkObjectResult)cartServiceControllerMock.EmptyCart(Userid);  
            //assert
            Assert.AreEqual(expectedMessage, response.Value);
        }
    }
}
