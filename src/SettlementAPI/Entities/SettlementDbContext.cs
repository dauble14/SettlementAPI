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

        public DbSet<Friend> Friends { get; set; }
        public DbSet<ProductSettlement> ProductSettlements { get; set; }

        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<ProductSettlement>()
            //    .HasKey(x => new { x.ProductId, x.SettlementId });
            modelBuilder.Entity<ProductSettlement>().HasKey(x => x.ProductSettlementId);


            modelBuilder.ApplyConfiguration(new RoleConfiguation());

            base.OnModelCreating(modelBuilder);

        }

    }
}
