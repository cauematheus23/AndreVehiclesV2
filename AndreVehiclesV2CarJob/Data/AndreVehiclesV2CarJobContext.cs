using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2CarJob.Data
{
    public class AndreVehiclesV2CarJobContext : DbContext
    {
        public AndreVehiclesV2CarJobContext (DbContextOptions<AndreVehiclesV2CarJobContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarJob> CarJob { get; set; } = default!;
    }
}
