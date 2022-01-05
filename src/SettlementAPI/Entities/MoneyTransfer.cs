using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SettlementAPI.Entities
{
    public class MoneyTransfer
    {
        [Key]
        public int Id { get; set; }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }

        public double Amount { get; set; }
        public string Currency { get; set; }

        public DateTime SendedAtTime { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

    }
}
