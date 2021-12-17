using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Entities
{
    public class User : IdentityUser
    {
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FriendIdCode { get; set; }

        [InverseProperty("FriendUser")]
        public ICollection<Friend> Follower { get; set; }
        [InverseProperty("User")]
        public ICollection<Friend> Following { get; set; }
        
    }
}
