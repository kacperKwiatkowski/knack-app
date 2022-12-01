using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile(IBoothRepository? boothRepository)
    {

        CreateMap<CreateBoothDto, Booth>();
        CreateMap<BoothDto, Booth>().ReverseMap();

        CreateMap<CreateProductDto, Product>();
        CreateMap<ProductDto, Product>().ReverseMap();

        CreateMap<CreateRateDto, RateDto>();
        CreateMap<RateDto, Rate>().ReverseMap();

        CreateMap<CreateStockDto, StockDto>();
        CreateMap<StockDto, Stock>().ReverseMap();
    }
}