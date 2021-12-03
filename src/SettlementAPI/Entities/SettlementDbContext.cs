using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SettlementAPI.Configurations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Entities
{
    public class SettlementDbContext :IdentityDbContext<User>
    {
        public SettlementDbContext(DbContextOptions<SettlementDbContext> options) : base(options)
        {}

        
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<FriendsLinking> FriendsLinking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ProductSettlement>()
                .HasKey(x => new { x.ProductId, x.SettlementId });

            //modelBuilder.Entity<Friend>(friendship =>
            //{
            //    friendship.HasOne(r=>r.User).WithMany(u=>u.)
            //});
                



            modelBuilder.ApplyConfiguration(new RoleConfiguation());

            base.OnModelCreating(modelBuilder);

        }

    }
}
