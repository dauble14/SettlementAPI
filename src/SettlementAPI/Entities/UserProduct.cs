using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Entities
{
    public class UserProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
