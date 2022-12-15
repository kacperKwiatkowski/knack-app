using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using product.Data;

namespace Product.IntegrationTests.Config;

public class TestingWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<ProductDbContext>));

            services.Remove(descriptor);
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ProductDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<TestingWebApplicationFactory<TProgram>>>();
                
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
                DataSeedFixture.SeedBooths(db);
                DataSeedFixture.SeedProducts(db);

            }
        });
    }
}