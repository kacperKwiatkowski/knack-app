using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Models;

namespace Product.IntegrationTests.Config;

public static class DataSeedFixture
{
    public static void SeedBooths(ProductDbContext db)
    {
        db.Booth.Add(new BoothEntity()
            {
                Title = "seedBooth",
                Description = "seedBooth"
            }
        );

        db.SaveChanges();
    }

    public static void SeedProducts(ProductDbContext db)
    {
        List<BoothEntity> all = db.Booth.ToList();

        var parentBooth = db.Booth
            .Where(b => b.Id == db.Booth.First().Id)
            .Include(b => b.Products)
            .SingleOrDefault();

        var productToSave = new product.Models.ProductEntity()
        {
            Title = "seedProduct",
            Description = "seedProduct"
        };
        
        parentBooth.Products.Add(productToSave);
        
        db.SaveChanges();
    }
}