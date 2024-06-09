using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Client.Data
{
    public class AndreVehiclesV2ClientContext : DbContext
    {
        public AndreVehiclesV2ClientContext (DbContextOptions<AndreVehiclesV2ClientContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Adress> Adress { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            modelBuilder.Entity<Models.Adress>().ToTable("Adress");
            
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
        }
    }
}
