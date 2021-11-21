using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Entities
{
    public class SettlementDbContext :DbContext
    {
        public SettlementDbContext(DbContextOptions<SettlementDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Settlement> Settlements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ProductSettlement>()
                .HasKey(x => new { x.ProductId, x.SettlementId });

            base.OnModelCreating(modelBuilder);

        }

    }
}
