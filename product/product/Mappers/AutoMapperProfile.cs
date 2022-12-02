using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<CreateBoothDto, Booth>();
        CreateMap<BoothDto, Booth>().ReverseMap();

        CreateMap<CreateProductDto, Product>()
            .ForMember(
                dest => dest.Booth, 
                opt => opt.MapFrom(src => new Booth(){Id = src.BoothId}));;
        CreateMap<ProductDto, Product>().ReverseMap();

        CreateMap<CreateRateDto, Rate>()            
            .ForMember(
            dest => dest.Product, 
            opt => opt.MapFrom(src => new Product(){Id = src.ProductId}));
        CreateMap<RateDto, Rate>().ReverseMap();

        CreateMap<CreateStockDto, Stock>()
            .ForMember(
                dest => dest.Product, 
                opt => opt.MapFrom(src => new Product(){Id = src.ProductId}));
        CreateMap<StockDto, Stock>();
        CreateMap<Stock, StockDto>();
    }
}