using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Payment.Data
{
    public class AndreVehiclesV2PaymentContext : DbContext
    {
        public AndreVehiclesV2PaymentContext (DbContextOptions<AndreVehiclesV2PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Payment> Payment { get; set; } = default!;
        public DbSet<Models.Pix> Pix { get; set; } = default!;
        public DbSet<Models.Card> Card { get; set; } = default!;
        public DbSet<Models.Boleto> Boleto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Payment>().ToTable("Payment");
            modelBuilder.Entity<Models.Pix>().ToTable("Pix");
            modelBuilder.Entity<Models.Card>().ToTable("Card");
            modelBuilder.Entity<Models.Boleto>().ToTable("Boleto");
        }
    }
}
