using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using DeveloperStoreBack.Api.Controllers;
using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DeveloperStoreBack.Tests.Unit.Controllers
{
    public class ItemControllerTests
    {
        private readonly Mock<IItemRepository> _itemRepositoryMock;
        private readonly ItemService _itemService;
        private readonly ItemController _itemController;

        public ItemControllerTests()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemRepositoryMock.Object);
            _itemController = new ItemController(_itemService);
        }

        
        [Fact]
        public async Task UpdateItem_ReturnsNoContent_WhenItemIsUpdated()
        {
            // Arrange
            var itemId = ObjectId.GenerateNewId().ToString();
            var itemDto = new ItemDto { Id = itemId, ProductId = "Updated Product", Name = "Updated Item", UnitPrice = 15.0m, StockQuantity = 10 };
            var item = new Item { Id = ObjectId.Parse(itemId), ProductId = "Updated Product", Name = "Updated Item", UnitPrice = 15.0m, StockQuantity = 10 };
            _itemRepositoryMock.Setup(repo => repo.UpdateAsync(item)).Returns(Task.CompletedTask);

            // Act
            var result = await _itemController.UpdateItem(itemId, itemDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteItem_ReturnsNoContent_WhenItemIsDeleted()
        {
            // Arrange
            var itemId = ObjectId.GenerateNewId().ToString();
            _itemRepositoryMock.Setup(repo => repo.DeleteAsync(itemId)).Returns(Task.CompletedTask);

            // Act
            var result = await _itemController.DeleteItem(itemId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}