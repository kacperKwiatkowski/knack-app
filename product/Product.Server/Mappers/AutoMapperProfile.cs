using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<CreateBoothDto, BoothEntity>();
        CreateMap<BoothDto, BoothEntity>().ReverseMap();

        CreateMap<CreateProductDto, ProductEntity>()
            .ForMember(
                dest => dest.Booth, 
                opt => opt.MapFrom(src => new BoothEntity(){Id = src.BoothId}));;
        CreateMap<ProductDto, ProductEntity>().ReverseMap();

        CreateMap<CreateRateDto, RateEntity>()            
            .ForMember(
            dest => dest.Product, 
            opt => opt.MapFrom(src => new ProductEntity(){Id = src.ProductId}));
        CreateMap<RateDto, RateEntity>().ReverseMap();

        CreateMap<CreateStockDto, StockEntity>()
            .ForMember(
                dest => dest.Product, 
                opt => opt.MapFrom(src => new ProductEntity(){Id = src.ProductId}));
        CreateMap<StockDto, StockEntity>();
        CreateMap<StockEntity, StockDto>();
    }
}