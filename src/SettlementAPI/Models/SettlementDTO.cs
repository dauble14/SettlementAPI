using SettlementAPI.Entities;
using System.Collections.Generic;

namespace SettlementAPI.Models
{
    public class SettlementDTO
    {
        public int SettlementId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }


        public User CreatedByUser { get; set; }
        public ICollection<ProductSettlement> ProductSettlementList { get; set; }
    }
}
