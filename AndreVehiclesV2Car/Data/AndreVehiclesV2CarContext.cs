using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Car.Data
{
    public class AndreVehiclesV2CarContext : DbContext
    {
        public AndreVehiclesV2CarContext (DbContextOptions<AndreVehiclesV2CarContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Car> Car { get; set; } = default!;
    }
}
