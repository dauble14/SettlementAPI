using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SettlementAPI.Entities
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FriendUserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("FriendUserId")]
        public User FriendUser { get; set; }

        public DateTime? RequestTime { get; set; }
        
        public FriendRequestFlag FriendRequestFlag { get; set; }

    }

    public enum FriendRequestFlag
    {
        None = 0,
        Approved,
        Rejected,
        Blocked,
        Spam
    }


}
