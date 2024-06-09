using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Purchase.Data
{
    public class AndreVehiclesV2PurchaseContext : DbContext
    {
        public AndreVehiclesV2PurchaseContext (DbContextOptions<AndreVehiclesV2PurchaseContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Purchase> Purchase { get; set; } = default!;
    }
}
