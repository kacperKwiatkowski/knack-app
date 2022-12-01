using AutoMapper;
using product.Dto;
using product.Models;

namespace product.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateBoothDto, Booth>();
        CreateMap<BoothDto, Booth>();
        CreateMap<Booth, BoothDto>();
        
        CreateMap<CreateProductDto, Product>();
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
        
        CreateMap<CreateRateDto, RateDto>();
        CreateMap<RateDto, Rate>();
        CreateMap<Rate, RateDto>();
        
        CreateMap<CreateStockDto, StockDto>();
        CreateMap<StockDto, Stock>();
        CreateMap<Stock, StockDto>();
    }
}