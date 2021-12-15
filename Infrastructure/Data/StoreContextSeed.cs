using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class StoreContextSeed
  {
    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
    {
      try
      {
        if (!context.ProductBrands.Any())
        {
          var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
          var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
          foreach (var productBrand in brands)
          {
            await context.ProductBrands.AddAsync(productBrand);
          }
          await context.SaveChangesAsync();
        }
        if (!context.ProductTypes.Any())
        {
          var brandsTypes = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
          var types = JsonSerializer.Deserialize<List<ProductType>>(brandsTypes);
          foreach (var productType in types)
          {
            await context.ProductTypes.AddAsync(productType);
          }
          await context.SaveChangesAsync();
        }
        if (!context.Products.Any())
        {
          var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
          var products = JsonSerializer.Deserialize<List<Product>>(productsData);
          foreach (var product in products)
          {
            await context.Products.AddAsync(product);
          }
          await context.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        var logger = loggerFactory.CreateLogger<StoreContextSeed>();
        logger.LogError(ex.Message);
      }
    }
  }
}