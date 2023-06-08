using brewery.Models;
using brewery.Repository;
using brewery.Repository.IRepository;

namespace brewery.Services; 

public class BrewingService {
    private readonly IInventoryRepository _inventoryRepository;

    public BrewingService(IInventoryRepository inventoryRepository) {
        _inventoryRepository = inventoryRepository;
    }

    public async Task CheckLowInventory(List<Beer> beers) {
        foreach (var beer in beers) {
            var inventory = await _inventoryRepository.Get(inv => inv.BeerId == beer.Id);
            if (inventory.QuantityOnHand <= beer.MinOnHand) {
                inventory.QuantityOnHand = 200;
                await _inventoryRepository.Update(inventory);
            }
        }
    }
}