namespace SettlementAPI.Entities
{
    public class ProductSettlement
    {
        public int ProductSettlementId { get; set; }
        public int ProductId { get; set; }
        public int SettlementId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Settlement Settlement { get; set; }
        public virtual User User { get; set; }

    }
}
