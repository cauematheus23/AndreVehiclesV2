using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Employee.Data
{
    public class AndreVehiclesV2EmployeeContext : DbContext
    {
        public AndreVehiclesV2EmployeeContext (DbContextOptions<AndreVehiclesV2EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Person> Person { get; set; } = default!;
        public DbSet<Models.Employee> Employee { get; set; } = default!;
        public DbSet<Models.Client> Client { get; set; } = default!;
        public DbSet<Models.Adress> Adress { get; set; } = default!;
        public DbSet<Models.Position> Position { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Person>().ToTable("Person");
            modelBuilder.Entity<Models.Position>().ToTable("Position");
            modelBuilder.Entity<Models.Adress>().ToTable("Adress");
            modelBuilder.Entity<Models.Client>().ToTable("Client");
            modelBuilder.Entity<Models.Employee>().ToTable("Employee");
            modelBuilder.Entity<Models.Person>().HasKey(p => p.Document);
        }

    }
}
