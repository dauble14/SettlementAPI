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

        //public DbSet<User> Users { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ProductSettlement>()
                .HasKey(x => new { x.ProductId, x.SettlementId });
            



            modelBuilder.ApplyConfiguration(new RoleConfiguation());

            base.OnModelCreating(modelBuilder);

        }

    }
}
