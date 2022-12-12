using AutoMapper;
using product.Dto;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class BoothService : IBoothService
{
    private readonly IMapper _mapper;
    private readonly IBoothRepository _boothRepository;

    public BoothService(
        IMapper mapper,
        IBoothRepository boothRepository
    )
    {
        _mapper = mapper;
        _boothRepository = boothRepository;
    }

    public async Task<List<BoothDto>> GetAllBooths()
    {
        return _mapper.Map<List<BoothDto>>(await _boothRepository.GetAllBooths());
    }

    public Task DeleteBooth(Guid boothId)
    {
        return _boothRepository.DeleteBooth(boothId);
    }

    public Task SaveBooth(CreateBoothDto boothToSave)
    {
        return _boothRepository.SaveBooth(_mapper.Map<Booth>(boothToSave));
    }

    // public Task SaveTestEntities()
    // {
    //     Stock stock = new Stock();
    //     stock.Category = CategoryEnum.Clothes;
    //     stock.Department = DepartmentEnum.Metal;
    //     stock.Gender = GenderEnum.Unisex;
    //     stock.Size = SizeEnum.ExtraLarge;
    //     stock.Price = 199.99;
    //     stock.Quantity = 2;
    //
    //     Rate rate = new Rate();
    //
    //     Product.Server Product.Server = new Product.Server();
    //     Product.Server.Title = "Iron chain-mail";
    //     Product.Server.Description = "Hand crafted hain-mail for a costume.";
    //     Product.Server.Stocks = new List<Stock>() { stock };
    //     Product.Server.Rates = new List<Rate>() { rate };
    //
    //     Booth booth = new Booth();
    //     booth.Title = "Metallica";
    //     booth.Description = "Metal craftsmanship";
    //     booth.Product.Server = new List<Product.Server>() { Product.Server };
    //
    //     return _boothRepository.SaveBoothWithProduct(booth);
    // }
}