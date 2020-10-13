using NordicBio.api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Services
{
    public class ProductsService : IProductsService
    {
        public ICollection<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product(){ Name="ASUS Zepherus ", Price = 1299.90},
                new Product(){ Name="SurfaceBook 3", Price = 1599.90}                
            };
        }
    }
}
