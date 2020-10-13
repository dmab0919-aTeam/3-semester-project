using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicBio.api.Domain
{
    enum SodaSize {Small, Medium, Large}
    public class Soda
    {

        private SodaSize _size;

        public string Name { get; set; }
        public double Price { get; set; }
        
    }
}