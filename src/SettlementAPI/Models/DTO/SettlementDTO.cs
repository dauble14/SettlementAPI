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
        public DateTime CreatedAtTime { get; set; }
        public DateTime ModifiedAtTime { get; set; }
    }

    public class SettlementOverallDTO
    {
        public int SettlementId { get; set; }
        public bool IsCreator { get; set; }
        //public string CreatedByUserId { get; set; }
        public DateTime CreatedAtTime { get; set; }
        public DateTime ModifiedAtTime { get; set; }
    }

    public class SettlementDetailDTO 
    {
        public int SettlementId { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public List<ProductDTO> Products { get; set; }
    }

    public class SettlementDetailForCreatorDTO
    {
        public int SettlementId { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public List<ProductDetailForCreatorDTO> Products { get; set; }
    }

}
