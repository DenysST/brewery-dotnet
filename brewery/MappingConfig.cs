using AutoMapper;
using brewery.Models;
using brewery.Models.Dto;

namespace brewery; 

public class MappingConfig : Profile{
    public MappingConfig() {
        CreateMap<Beer, BeerDto>();
        CreateMap<BeerDto, Beer>();
        CreateMap<BeerCreateDto, Beer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
            .ForMember(dest => dest.Version, opt => opt.Ignore());
        CreateMap<BeerUpdateDto, Beer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
            .ForMember(dest => dest.Version, opt => opt.Ignore());
        CreateMap<Inventory, InventoryDto>();
        CreateMap<InventoryDto, Inventory>();
    }
}