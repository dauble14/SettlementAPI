using SettlementAPI.Models.DTO;
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

    public class CreateSingleProductDTO
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double FullPrice { get; set; }

    }

    public class ProductToAddDTO
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double FullPrice { get; set; }
        public string[] UsersWhoTakeProduct { get; set; }
        
    }

    public class ProductDetailForCreatorDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double FullPrice { get; set; }
        public List<ProductUsersDTO> Users { get; set; }
    }
}
