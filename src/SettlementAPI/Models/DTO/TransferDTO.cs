using SettlementAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Models.DTO
{
    public class TransferDTO
    {
        public string ReceiverId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }

    }

    public class MoneyTransferDTO
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime SendedAtTime { get; set; }
        public TransferRequestFlag TransferRequestFlag { get; set; }
    }

    public enum TransferResponseAction
    {
        Reject=0,
        Accept
    }


}
