using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Sale.Data
{
    public class AndreVehiclesV2SaleContext : DbContext
    {
        public AndreVehiclesV2SaleContext (DbContextOptions<AndreVehiclesV2SaleContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Sale> Sale { get; set; } = default!;
    }
}
