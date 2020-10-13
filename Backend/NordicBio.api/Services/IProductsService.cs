using NordicBio.api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Services
{
    public interface IProductsService
    {
        public ICollection<Product> GetAll();
    }
}
