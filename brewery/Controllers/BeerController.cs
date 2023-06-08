using AutoMapper;
using brewery.Models;
using brewery.Models.Dto;
using brewery.Repository.IRepository;
using brewery.Services;
using Microsoft.AspNetCore.Mvc;

namespace brewery.Controllers;

[Route("api/v1/beers")]
[ApiController]
public class BeerController : ControllerBase {
    private readonly IBeerRepository _repository;
    private readonly IMapper _mapper;
    private readonly BeerService _beerService;

    public BeerController(IBeerRepository repository, IMapper mapper, BeerService beerService) {
        _repository = repository;
        _mapper = mapper;
        _beerService = beerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BeerDto>>> GetBeers(bool showInventoryOnHand = false) {
        var beers = await _beerService.GetAllBeers(showInventoryOnHand);
        return Ok(beers);
    }

    [HttpPost]
    public async Task<ActionResult<BeerDto>> CreateBeer([FromBody] BeerCreateDto createDto) {
        Beer beer = await _beerService.CreateBeer(_mapper.Map<Beer>(createDto));
        return Ok(_mapper.Map<BeerDto>(beer));
    }

    [HttpPut]
    public async Task<ActionResult<BeerDto>> UpdateBeer([FromBody] BeerUpdateDto updateDto) {
        Beer beer = await _repository.Get(beer => beer.Id == updateDto.Id);
        if (beer == null) {
            return NotFound();
        }
        var updatedBeer = await _beerService.UpdateBeer(beer, updateDto);
        return Ok(_mapper.Map<BeerDto>(updatedBeer));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BeerDto>> GetBeerById(Guid id) {
        var beer = await _beerService.GetById(id);
        return Ok(_mapper.Map<BeerDto>(beer));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBeer(Guid id) {
        Beer beer = await _beerService.GetById(id);
        if (beer == null) {
            return NotFound();
        }
        await _beerService.Delete(beer);
        return NoContent();
    }
}