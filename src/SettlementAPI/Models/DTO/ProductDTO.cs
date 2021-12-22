using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double FullPrice { get; set; }
    }
}
