using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalogService.Controllers;

namespace ProductCatalogServiceTest
{
    [TestClass]
    public class ProductCatalogServiceControllerTest
    {
        ProductCatalogServiceController pcscMock;

        [TestInitialize]
        public void Initialize()
        {
            pcscMock = new ProductCatalogServiceController(true);
        }

        [TestMethod]
        public void GetById_ValidId_ProductDTO()
        {
            //Arrange
            var response = (OkResult)pcscMock.GetById("");
            //Act
            //Assert
        }
    }
}
