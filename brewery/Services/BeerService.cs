using AutoMapper;
using brewery.Models;
using brewery.Models.Dto;
using brewery.Repository.IRepository;

namespace brewery.Services; 

public class BeerService {
    private readonly IBeerRepository _repository;
    private readonly InventoryService _inventoryService;
    private readonly BrewingService _brewingService;
    private readonly IMapper _mapper;

    public BeerService(IBeerRepository repository, InventoryService inventoryService, IMapper mapper, BrewingService brewingService) {
        _repository = repository;
        _inventoryService = inventoryService;
        _mapper = mapper;
        _brewingService = brewingService;
    }

    public async Task<Beer> CreateBeer(Beer beer) {
        beer.CreatedDate = DateTime.Now;
        beer.LastModifiedDate = DateTime.Now;
        beer.Version = 1;
        beer.QuantityToBrew = 200;
        beer.MinOnHand = 30;
        await _repository.Create(beer);
        var createInventoryDto = new CreateInventoryDto {
            BeerId = beer.Id
        };
        await _inventoryService.CreateInventory(createInventoryDto);
        return beer;
    }

    public async Task<Beer> UpdateBeer(Beer beer, BeerUpdateDto updateDto) {
        beer.BeerStyle = updateDto.BeerStyle;
        beer.BeerName = updateDto.BeerName;
        beer.Price = updateDto.Price;
        beer.BeerName = updateDto.BeerName;
        beer.LastModifiedDate = DateTime.Now;
        beer.Version += 1;
        beer.MinOnHand = updateDto.MinOnHand;
        beer.QuantityToBrew = updateDto.QuantityToBrew;
        await _repository.Update(beer);
        return beer;
    }

    public async Task<List<BeerDto>> GetAllBeers(bool showInventoryOnHand) {
        var beers = await _repository.GetAll();
        await _brewingService.CheckLowInventory(beers);
        var beerDtos = _mapper.Map<List<BeerDto>>(beers);
        if (showInventoryOnHand) {
            foreach (var beer in beerDtos) {
                var inventory = await _inventoryService.GetInventoryForBeer(beer.Id);
                beer.QuantityOnHand = inventory.QuantityOnHand;
            }
        }

        return beerDtos;
    }

    public async Task<Beer> GetById(Guid id) {
        var beer = await _repository.Get(beer => beer.Id == id);
        await _brewingService.CheckLowInventory(new List<Beer>{beer});
        return beer;
    }

    public async Task Delete(Beer beer) {
        await _repository.Remove(beer);
    }
}