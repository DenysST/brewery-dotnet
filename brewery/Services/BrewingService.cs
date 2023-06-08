namespace brewery.Services; 

public class BrewingService {
    private readonly InventoryService _inventoryService;

    public BrewingService(InventoryService inventoryService) {
        _inventoryService = inventoryService;
    }
    
}