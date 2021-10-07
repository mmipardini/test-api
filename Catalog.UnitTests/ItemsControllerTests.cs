using System;
using System.Threading.Tasks;
using Catalog.Controllers;
using Catalog.Interfaces;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.UnitTests
{
    public class ItemsControllerTests
    {
        [Fact]
        // UnitOfWork_StateUnderTest_ExpectedBehavior
        public async Task GetItemsAsync_WithUnexistingItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IItemsRepository>();
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);

            var loggerStub = new Mock<ILogger<ItemsController>>();

            var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

            // Act
            var result = await controller.GetItemAsync(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
