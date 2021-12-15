using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class ProductRepository : IProductRepository
  {
    private readonly StoreContext _context;
    public ProductRepository(StoreContext context)
    {
      this._context = context;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
      var brands = await _context.ProductBrands.ToListAsync();
      return brands;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      var product = await _context.Products
      .Include(t => t.ProductType)
      .Include(b => b.ProductBrand)
      .FirstOrDefaultAsync(p => p.Id == id);
      return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
      var products = await _context.Products
      .Include(t => t.ProductType)
      .Include(b => b.ProductBrand)
      .ToListAsync();
      return products;
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
      var types = await _context.ProductTypes.ToListAsync();
      return types;
    }
  }
}