using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Models
{
    public class CreateSettlementDTO
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
    
    public class SettlementDTO : CreateSettlementDTO
    {
        public int SettlementId { get; set; }
    }
}
