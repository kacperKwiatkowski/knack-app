using Microsoft.AspNetCore.Mvc;
using product.Enums;
using product.Models;
using product.Repository;

namespace product.Service.Impl;

public class BoothService : IBoothService
{
    private readonly IBoothRepository _boothRepository;

    public BoothService(
        IBoothRepository boothRepository
    )
    {
        _boothRepository = boothRepository;
    }


    public async Task<List<Booth>> GetAllBooths()
    {
        return await _boothRepository.GetAllBooths();
    }

    public Task DeleteBooth( Guid boothId)
    {
        return _boothRepository.DeleteBooth(boothId);
    }

    public Task SaveBooth(Booth boothToSave)
    {
        return _boothRepository.SaveBooth(boothToSave);
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
    //     Product product = new Product();
    //     product.Title = "Iron chain-mail";
    //     product.Description = "Hand crafted hain-mail for a costume.";
    //     product.Stocks = new List<Stock>() { stock };
    //     product.Rates = new List<Rate>() { rate };
    //
    //     Booth booth = new Booth();
    //     booth.Title = "Metallica";
    //     booth.Description = "Metal craftsmanship";
    //     booth.Products = new List<Product>() { product };
    //
    //     return _boothRepository.SaveBoothWithProduct(booth);
    // }
}