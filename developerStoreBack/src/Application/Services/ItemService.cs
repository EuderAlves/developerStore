using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using System;

namespace DeveloperStoreBack.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> AddItem(ItemDto itemDto)
        {
            var item = new Item
            {
                ProductId = itemDto.ProductId,
                Categoria = itemDto.Categoria,
                UnitPrice = itemDto.UnitPrice,
                Image = itemDto.Image,
                StockQuantity = itemDto.StockQuantity
            };

            await _itemRepository.InsertAsync(item);
            return item;
        }

        public async Task<IEnumerable<ItensAllDto>> GetAllItems()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return items.Select(ItensAllDto.FromItem).ToList();
        }

        public async Task<Item> GetItemById(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("ID inválido.");
            }

            return await _itemRepository.GetItemByIdAsync(objectId.ToString());
        }

        public async Task UpdateItem(string id, ItemDto itemDto)
        {
            var existingItem = await _itemRepository.GetItemByIdAsync(id);
            if (existingItem != null)
            {
                existingItem.ProductId = itemDto.ProductId;
                existingItem.Categoria = itemDto.Categoria;
                existingItem.UnitPrice = itemDto.UnitPrice;
                existingItem.Image = itemDto.Image;
                existingItem.StockQuantity = itemDto.StockQuantity;
                await _itemRepository.UpdateAsync(existingItem);
            }
        }

        public async Task DeleteItem(string id)
        {
            await _itemRepository.DeleteAsync(id);
        }
    }
}