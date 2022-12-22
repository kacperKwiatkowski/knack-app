using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using product.Data;
using product.Repository;
using product.Repository.Impl;
using product.Service;
using product.Service.Impl;
using product.Validators;
using Product.Validators.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductDbContext>(option =>
    option
        .UseNpgsql( builder.Configuration.GetConnectionString("WebApiDatabase"))
);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductValidator, ProductValidator>();

builder.Services.AddScoped<IBoothService, BoothService>();
builder.Services.AddScoped<IBoothRepository, BoothRepository>();
builder.Services.AddScoped<IBoothValidator, BoothValidator>();

builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddScoped<IRateRepository, RateRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    
}