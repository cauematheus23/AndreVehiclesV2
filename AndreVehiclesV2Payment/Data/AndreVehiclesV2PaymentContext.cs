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
    }
}
