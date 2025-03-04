using Xunit;
using Moq;
using DeveloperStoreBack.Application.Services;
using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Notifications;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DeveloperStoreBack.Tests.Unit.Services
{
    public class SaleServiceTests
    {
        private readonly Mock<ISaleRepository> _mockSaleRepository;
        private readonly SaleService _saleService;

        public SaleServiceTests()
        {
            _mockSaleRepository = new Mock<ISaleRepository>();
            _saleService = new SaleService(_mockSaleRepository.Object, new SaleNotificationService());
        }

        private Sale CreateMockSale(string saleId)
        {
            return new Sale
            {
                Id = MongoDB.Bson.ObjectId.Parse("5f8d0e1a3b5c1e2d12345678"),
                SaleNumber = 1,
                SaleDate = DateTime.UtcNow,
                CustomerEmail = "euder@developerstore.com",
                Branch = "Filial 1",
                IsCanceled = false,
                IsFinalized = false,
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductId = "Stella Artois", Quantity = 4, UnitPrice = 6.5m, Discount = 0 }
                }
            };
        }

        [Fact]
        public async Task RegisterSale_ShouldReturnSale_WhenSaleIsValid()
        {
            // Arrange
            var saleDto = new SaleDto
            {
                CustomerEmail = "euder@developerstore.com",
                Branch = "Filial 1",
                Items = new List<SaleItemDto>
        {
            new SaleItemDto { ProductId = "Stella Artois", Quantity = 4, UnitPrice = 6.5m, Discount = 0 }
        }
            };

            // Mock do retorno para o próximo número da venda
            _mockSaleRepository.Setup(repo => repo.GetNextSaleNumberAsync()).ReturnsAsync(1);

            // Act
            var sale = await _saleService.RegisterSale(saleDto);

            // Assert
            Assert.NotNull(sale);
            Assert.Equal("euder@developerstore.com", sale.CustomerEmail);
            Assert.Equal("Filial 1", sale.Branch);
            Assert.Equal(23.4m, sale.TotalValue);
            Assert.NotNull(sale.Items);
            Assert.NotEmpty(sale.Items);
        }

        [Fact]
        public async Task CancelSale_ShouldMarkSaleAsCanceled()
        {
            // Arrange
            var saleId = "some_sale_id";
            var sale = CreateMockSale(saleId); // Use o método auxiliar

            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);

            // Act
            await _saleService.CancelSale(saleId);

            // Assert
            Assert.True(sale.IsCanceled);
        }

        [Fact]
        public async Task CancelSale_ShouldThrowException_WhenSaleIsFinalized()
        {
            // Arrange
            var saleId = "some_sale_id";
            var sale = CreateMockSale(saleId);
            sale.IsFinalized = true;

            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _saleService.CancelSale(saleId));
            Assert.Equal("Venda não encontrada ou já finalizada.", exception.Message);
        }

        [Fact]
        public async Task CancelSaleItem_ShouldMarkItemAsCanceled_WhenItemExists()
        {
            // Arrange
            var saleId = "some_sale_id";
            var productId = "Stella Artois";
        
            // Criar uma venda mock
            var sale = CreateMockSale(saleId);
            sale.IsFinalized = false;
        
            // Configurar o mock do repositório
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);
        
            // Act
            await _saleService.CancelSaleItem(saleId, productId);
        
            // Assert
            Assert.True(sale.Items[0].IsCanceled); // Verifica se o item foi marcado como cancelado
            _mockSaleRepository.Verify(repo => repo.UpdateAsync(sale), Times.Once); // Verifica se o repositório foi atualizado
        }
        
        [Fact]
        public async Task CancelSaleItem_ShouldThrowException_WhenSaleIsFinalized()
        {
            // Arrange
            var saleId = "some_sale_id";
            var productId = "Stella Artois";
        
            var sale = CreateMockSale(saleId);
            sale.IsFinalized = true;
        
            // Configurar o mock do repositório
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);
        
            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _saleService.CancelSaleItem(saleId, productId));
            Assert.Equal("Venda não encontrada ou já finalizada.", exception.Message);
        }
        
        [Fact]
        public async Task CancelSaleItem_ShouldNotThrow_WhenItemDoesNotExist()
        {
            // Arrange
            var saleId = "some_sale_id";
            var productId = "NonExistentProduct";
        
            // Criar uma venda mock
            var sale = CreateMockSale(saleId);
            sale.IsFinalized = false;
        
            // Configurar o mock do repositório
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);
        
            // Act
            await _saleService.CancelSaleItem(saleId, productId);
        
            // Assert
            Assert.False(sale.Items[0].IsCanceled); // Verifica que o item não foi marcado como cancelado
            _mockSaleRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Sale>()), Times.Never); // Verifica que o repositório não foi atualizado
        }

        [Fact]
        public async Task FinalizeSale_ShouldMarkSaleAsFinalized()
        {
            // Arrange
            var saleId = "some_sale_id";
            var sale = CreateMockSale(saleId);

            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);

            // Act
            await _saleService.FinalizeSale(saleId);

            // Assert
            Assert.True(sale.IsFinalized);
        }

        [Fact]
        public async Task DeleteSale_ShouldRemoveSale_WhenSaleIsValid()
        {
            // Arrange
            var saleId = "some_sale_id";
            var sale = CreateMockSale(saleId);

            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);
            _mockSaleRepository.Setup(repo => repo.DeleteAsync(saleId)).Returns(Task.CompletedTask);

            // Act
            await _saleService.DeleteSale(saleId);

            // Assert
            _mockSaleRepository.Verify(repo => repo.DeleteAsync(saleId), Times.Once);
        }

        [Fact]
        public async Task UpdateSaleItem_ShouldUpdateItem_WhenSaleExistsAndNotFinalized()
        {
            // Arrange
            var saleId = "sale123";
            var sale = CreateMockSale(saleId);

            // Garanta que o SaleItem tenha o ProductId que você está atualizando
            var updatedItemDto = new SaleItemDto
            {
                ProductId = "Stella Artois", // Certifique-se de que isso corresponde ao mock
                Quantity = 5,
                UnitPrice = 100,
                Discount = 10
            };

            // Configura o mock para retornar a venda criada
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);

            // Act
            await _saleService.UpdateSaleItem(saleId, updatedItemDto);

            // Assert
            // Verifica se o repositório foi chamado para atualizar a venda
            _mockSaleRepository.Verify(repo => repo.UpdateAsync(sale), Times.Once);

            // Verifica se as propriedades do item foram atualizadas corretamente
            var itemToUpdate = sale.Items.Find(i => i.ProductId == updatedItemDto.ProductId);
            Assert.NotNull(itemToUpdate); // Assegure-se de que o item foi encontrado
            Assert.Equal(updatedItemDto.Quantity, itemToUpdate.Quantity);
            Assert.Equal(updatedItemDto.UnitPrice, itemToUpdate.UnitPrice);
            Assert.Equal(updatedItemDto.Discount, itemToUpdate.Discount);
        }

        [Fact]
        public async Task UpdateSaleItem_ShouldThrowException_WhenSaleIsFinalized()
        {
            // Arrange
            var saleId = "sale123";
            var sale = CreateMockSale(saleId);
            sale.IsFinalized = true;

            // Configura o mock para retornar a venda criada
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync(sale);

            var updatedItemDto = new SaleItemDto
            {
                ProductId = "product123",
                Quantity = 5,
                UnitPrice = 100,
                Discount = 10
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _saleService.UpdateSaleItem(saleId, updatedItemDto));

            Assert.Equal("Venda não encontrada ou já finalizada.", exception.Message);
        }

        [Fact]
        public async Task UpdateSaleItem_ShouldThrowException_WhenSaleNotFound()
        {
            // Arrange
            var saleId = "invalidSaleId";
            var updatedItemDto = new SaleItemDto
            {
                ProductId = "product123",
                Quantity = 5,
                UnitPrice = 100,
                Discount = 10
            };

            // Configura o mock para retornar null
            _mockSaleRepository.Setup(repo => repo.GetSaleByIdAsync(saleId)).ReturnsAsync((Sale?)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _saleService.UpdateSaleItem(saleId, updatedItemDto));

            Assert.Equal("Venda não encontrada ou já finalizada.", exception.Message);
        }

        [Fact]
        public void CalculateDiscountPercentage_ShouldReturnCorrectPercentage_WhenDiscountsAreApplied()
        {
            // Arrange
            var items = new List<SaleItem>
            {
                new SaleItem { ProductId = "Stella Artois", Quantity = 2, UnitPrice = 50, Discount = 10 }, // Total Price = 100, Total Discount = 10
                new SaleItem { ProductId = "Another Product", Quantity = 1, UnitPrice = 100, Discount = 0 }  // Total Price = 100, Total Discount = 0
            };

            // Act
            var result = _saleService.CalculateDiscountPercentage(items);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void CalculateDiscountPercentage_ShouldReturnZero_WhenNoItems()
        {
            // Arrange
            var items = new List<SaleItem>();

            // Act
            var result = _saleService.CalculateDiscountPercentage(items);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDiscountPercentage_ShouldReturnZero_WhenTotalPriceIsZero()
        {
            // Arrange
            var items = new List<SaleItem>
            {
                new SaleItem { ProductId = "Empty Product", Quantity = 0, UnitPrice = 50, Discount = 10 },
                new SaleItem { ProductId = "Another Empty Product", Quantity = 0, UnitPrice = 100, Discount = 0 }
            };

            // Act
            var result = _saleService.CalculateDiscountPercentage(items);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDiscountPercentage_ShouldReturnCorrectPercentage_WhenOnlyDiscounts()
        {
            // Arrange
            var items = new List<SaleItem>
            {
                new SaleItem { ProductId = "Full Discount Product", Quantity = 1, UnitPrice = 100, Discount = 100 }
            };

            // Act
            var result = _saleService.CalculateDiscountPercentage(items);

            // Assert
            Assert.Equal(100, result);
        }
    }
}