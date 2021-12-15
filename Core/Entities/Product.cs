using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }

    // Relationship Product and Product Type
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }

    // Relationship Product and Product Brand
    public ProductBrand ProductBrand { get; set; }
    public int ProductBrandId { get; set; }
  }
}