using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SettlementAPI.Entities
{
    public class Settlement
    {
        public int SettlementId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime CreatedAtTime { get; set; }
        public DateTime ModifiedAtTime { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual ICollection<ProductSettlement> ProductSettlementList { get; set; }
        
    }
}
