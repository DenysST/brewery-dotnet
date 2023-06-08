using AutoMapper;
using brewery.Models;
using brewery.Models.Dto;
using brewery.Repository.IRepository;

namespace brewery.Services; 

public class InventoryService {
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository) {
        _repository = repository;
    }

    public async Task CreateInventory(CreateInventoryDto inventoryDto) {
        var inventory = new Inventory {
            Version = 1,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now,
            BeerId = inventoryDto.BeerId,
            QuantityOnHand = 0
        };

        await _repository.Create(inventory);
    }

    public async Task<Inventory> GetInventoryForBeer(Guid beerId) {
        return await _repository.Get(inv => inv.BeerId == beerId);
    }

    public async Task UpdateInventory(CreateInventoryDto inventoryDto) {
        var inventory = await _repository.Get(inv => inv.Id == inventoryDto.Id);
        if (inventory == null) {
            throw new Exception("Repository is not exist");
        }

        inventory.QuantityOnHand = inventoryDto.QuantityOnHand;
        inventory.LastModifiedDate = DateTime.Now;
        await _repository.Update(inventory);
    }
}